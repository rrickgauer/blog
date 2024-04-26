using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.ViewModels.Base;
using Blog.WpfGui.Views.Pages;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Wpf.Ui;
using static Blog.WpfGui.Messenger.ViewMessages;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntriesViewModel : NavigableViewModel,
    IRecipient<EntryFormSavedMessage>
{
    private readonly IEntryService _entryService;
    private readonly EntryFormPage _entryFormPage;
    private readonly INavigationService _navigationService;

    public EntriesViewModel(IEntryService entryService, EntryFormPage entryFormPage, INavigationService navigationService)
    {
        _entryService = entryService;
        _entryFormPage = entryFormPage;
        _navigationService = navigationService;

        InitMessenger();
    }

    #region - Generated Properties -

    /// <summary>
    /// Entries
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<EntryTableView> _entries = new();

    [ObservableProperty]
    private bool _showLoadingSpinner = true;

    #endregion


    public void OnEntryDoubleClicked(EntryTableView entry)
    {
        EditItem(entry);
    }


    #region - INavigationAware -

    public override async void OnNavigatedTo()
    {
        base.OnNavigatedTo();

        await RefreshEntriesAsync();
    }

    #endregion


    #region - Commands -

    [RelayCommand]
    private void EditItem(EntryTableView entry)
    {
        var editArgs = GetEditModelFormArgs(entry);

        _entryFormPage.ViewModel.EditModel(editArgs);

        NavigateToEntryFormPage();
    }

    [RelayCommand]
    private void DeleteEntry(EntryTableView entry)
    {
        if (!ConfirmDelete())
        {
            return;
        }
    }

    [RelayCommand]
    private void EditEntryFile(EntryTableView entry)
    {
        int x = 10;
    }

    [RelayCommand]
    private void ViewEntryPage(EntryTableView entry)
    {
        int x = 10;
    }


    [RelayCommand]  
    private void CreateNewEntry()
    {
        var newModelArgs = GetNewModelFormArgs();

        _entryFormPage.ViewModel.NewModel(newModelArgs);

        NavigateToEntryFormPage();
    }

    #endregion

    #region - Private Methods -

    private async Task RefreshEntriesAsync()
    {
        ShowLoadingSpinner = true;

        var entries = await _entryService.GetAllEntriesAsync();
        Entries.Clear();
        
        foreach (var entry in entries)
        {
            Entries.Add(entry);
        }

        ShowLoadingSpinner = false;
    }

    private NewModelFormArgs GetNewModelFormArgs()
    {
        return new()
        {
            MessengerToken = MessengerToken,
            Title = "New Entry",
            SaveButtonText = "Create Entry",
            CancelButtonText = "Cancel",
        };
    }

    private EditModelFormArgs<EntryTableView> GetEditModelFormArgs(EntryTableView entry)
    {
        return new()
        {
            Model = entry,
            Title = "Edit Entry",
            MessengerToken = MessengerToken,
        };
    }

    private static bool ConfirmDelete()
    {
        var promptResponse = NativeMessageBox.Show($"Are you sure you want to permanently delete this entry?", $"Confirm Delete", System.Windows.MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

        if (promptResponse == System.Windows.MessageBoxResult.Yes)
        {
            return true;
        }

        return false;
    }

    public async void Receive(EntryFormSavedMessage message)
    {
        var entry = (Entry)message.Value;

        await _entryService.SaveEntryAsync(entry);

        NavigateHere();
    }

    private void NavigateToEntryFormPage()
    {
        _navigationService.GetNavigationControl().Navigate(typeof(EntryFormPage));
    }

    private void NavigateHere()
    {
        _navigationService.GetNavigationControl().Navigate(typeof(EntriesPage));
    }

    #endregion
}
