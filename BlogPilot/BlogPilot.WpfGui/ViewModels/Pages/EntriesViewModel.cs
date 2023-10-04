using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Service.Interface;
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

    #endregion


    public EntriesViewModel(IEntryService entryService, INavigationService navigationService, CustomAlertService customAlertService)
    {
        _entryService = entryService;
        _navigation = navigationService.GetNavigationControl();
        _customAlertService = customAlertService;
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

    [RelayCommand]
    private void New()
    {
        NavigateToCreateEntryPage();
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
        
        SpinnerIsVisible = false;
    }

    private async Task<IEnumerable<EntryListItemControl>> GetEntryControlsAsync()
    {
        var entries = await _entryService.GetEntriesAsync();
        var controls = entries.Select(e => new EntryListItemControl(new(e)));

        return controls;
    }

    private void NavigateToCreateEntryPage()
    {
        _navigation.Navigate(typeof(CreateEntryPage));
    }


    #endregion
}
