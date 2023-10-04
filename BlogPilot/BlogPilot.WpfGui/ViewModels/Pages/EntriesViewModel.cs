using BlogPilot.Services.Domain.Enum;
using BlogPilot.Services.Domain.Helpers;
using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Service.Interface;
using BlogPilot.Services.Utilities;
using BlogPilot.WpfGui.Enums;
using BlogPilot.WpfGui.Messaging;
using BlogPilot.WpfGui.Other;
using BlogPilot.WpfGui.Services;
using BlogPilot.WpfGui.Views.Controls;
using BlogPilot.WpfGui.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace BlogPilot.WpfGui.ViewModels.Pages;

public partial class EntriesViewModel : ObservableObject, INavigationAware, IMessengerCompliant,
    IRecipient<EntryListItemEditMessage>,
    IRecipient<EntryListItemDeletedMessage>
{
    #region - Private Members -
    private readonly IEntryService _entryService;
    private readonly INavigation _navigation;
    private readonly CustomAlertService _customAlertService;
    #endregion

    #region - Generated Properties -

    /// <summary>
    /// Entries
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<EntryListItemControl> _entries = new();


    /// <summary>
    /// SpinnerIsVisible
    /// </summary>
    [ObservableProperty]
    private bool _spinnerIsVisible = false;

    /// <summary>
    /// SortOptions
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<EnumDescription<EntriesSortOption>> _sortOptions = new(EnumUtilities.GetDescriptions<EntriesSortOption>());

    /// <summary>
    /// SelectedSortOption
    /// </summary>
    [ObservableProperty]
    private EnumDescription<EntriesSortOption> _selectedSortOption;

    async partial void OnSelectedSortOptionChanged(EnumDescription<EntriesSortOption> value)
    {
        IsSortDropdownVisible = false;

        SearchInputText = string.Empty;

        await LoadEntriesAsync();
    }


    /// <summary>
    /// IsSortDropdownVisible
    /// </summary>
    [ObservableProperty]
    private bool _isSortDropdownVisible = false;


    /// <summary>
    /// IsFilterDropdownVisible
    /// </summary>
    [ObservableProperty]
    private bool _isFilterDropdownVisible = false;

    /// <summary>
    /// FilterOptions
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<EnumDescription<TopicReference>> _filterOptions = new(EnumUtilities.GetDescriptions<TopicReference>());

    /// <summary>
    /// SelectedFilterOption
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ClearSelectedFilterCommand))]
    private EnumDescription<TopicReference>? _selectedFilterOption = null;

    partial void OnSelectedFilterOptionChanged(EnumDescription<TopicReference>? value)
    {
        SearchInputText = string.Empty;

        if (value == null)
        {
            ShowAllControls();
        }
        else
        {
            FilterCurrentControls();
        }
    }

    /// <summary>
    /// SearchInputText
    /// </summary>
    [ObservableProperty]
    private string? _searchInputText = string.Empty;

    partial void OnSearchInputTextChanged(string? value)
    {
        if (!string.IsNullOrWhiteSpace(value) && value.Length > 2)
        {
            SearchForEntry(value);
        }
        else
        {
            FilterCurrentControls();
        }
    }

    #endregion


    public EntriesViewModel(IEntryService entryService, INavigationService navigationService, CustomAlertService customAlertService)
    {
        _entryService = entryService;
        _navigation = navigationService.GetNavigationControl();
        _customAlertService = customAlertService;

        SelectedSortOption = SortOptions[0];
    }

    #region - Messaging -

    public void Receive(EntryListItemEditMessage message)
    {
        WeakReferenceMessenger.Default.Send(new EditEntryMessage(message.Value));
        _navigation.Navigate(typeof(EditEntryPage));
    }

    public async void Receive(EntryListItemDeletedMessage message)
    {
        _customAlertService.Successful("Entry deleted");
        await LoadEntriesAsync();
    }

    #endregion


    #region - Commands - 

    /// <summary>
    /// NewCommand
    /// </summary>
    [RelayCommand]
    private void New()
    {
        NavigateToCreateEntryPage();
    }

    /// <summary>
    /// ToggleSortCommand
    /// </summary>
    [RelayCommand]
    private void ToggleSort()
    {
        ToggleSortDropdownVisibility();
    }

    /// <summary>
    /// ToggleFilterCommand
    /// </summary>
    [RelayCommand]
    private void ToggleFilter()
    {
        ToggleFilterDropdownVisibility();
    }

    [RelayCommand(CanExecute = nameof(CanClearSelectedFilter))]
    private void ClearSelectedFilter()
    {
        SelectedFilterOption = null;
        ToggleFilterDropdownVisibility();
    }


    private bool CanClearSelectedFilter()
    {
        if (SelectedFilterOption != null)
        {
            return true;
        }

        return false;
    }


    #endregion


    #region - INavigationAware -

    public void OnNavigatedFrom()
    {
        //throw new NotImplementedException();
    }

    public async void OnNavigatedTo()
    {
        await LoadEntriesAsync();
    }

    #endregion

    #region - Private Methods -

    private async Task LoadEntriesAsync()
    {
        SpinnerIsVisible = true;

        var controls = await GetEntryControlsAsync();
        Entries = new(controls);

        FilterCurrentControls();
        
        SpinnerIsVisible = false;
    }

    private async Task<IEnumerable<EntryListItemControl>> GetEntryControlsAsync()
    {
        var entries = await GetSortedEntriesAsync();
        var controls = entries.Select(e => new EntryListItemControl(new(e)));

        return controls;
    }

    private async Task<List<EntryTableView>> GetSortedEntriesAsync()
    {
        var entries = await _entryService.GetEntriesAsync();

        var currentSort = SelectedSortOption.Value;

        var sortedEntries = currentSort == EntriesSortOption.CreatedOn ? 
            entries.OrderByDescending(x => x.Date) : 
            entries.OrderBy(x => x.Title);

        return sortedEntries.ToList();

    }


    private void NavigateToCreateEntryPage()
    {
        _navigation.Navigate(typeof(CreateEntryPage));
    }

    private void ToggleSortDropdownVisibility()
    {
        IsSortDropdownVisible = !IsSortDropdownVisible;
    }

    private void ToggleFilterDropdownVisibility()
    {
        IsFilterDropdownVisible = !IsFilterDropdownVisible;
    }

    private void SearchForEntry(string searchText)
    {
        FilterCurrentControls();

        Entries.Where(c => !c.ViewModel.Entry.Title.ToLower().Contains(searchText.ToLower())).ToList().ForEach(c => c.ViewModel.Visibile = false);
    }

    private void FilterCurrentControls()
    {
        ShowAllControls();

        if (SelectedFilterOption != null)
        {
            FilterControlsByTopic((uint)SelectedFilterOption.Value);
        }
    }

    private void ShowAllControls()
    {
        foreach (var control in Entries)
        {
            control.ViewModel.Visibile = true;
        }
    }

    private void FilterControlsByTopic(uint topicId)
    {
        foreach (var control in Entries)
        {
            if (control.ViewModel.Entry.TopicId != topicId)
            {
                control.ViewModel.Visibile = false;
            }
        }
    }


    #endregion
}
