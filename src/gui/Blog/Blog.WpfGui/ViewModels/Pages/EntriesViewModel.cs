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


    #region - INavigationAware -

    public override async void OnNavigatedTo()
    {
        await RefreshEntriesAsync();
    }

    #endregion


    #region - Private Methods -

    private async Task RefreshEntriesAsync()
    {
        ShowLoadingSpinner = true;

        var entries = await _entryService.GetAllEntriesAsync();
        Entries = new(entries);

        ShowLoadingSpinner = false;
    }


    #endregion


    #region - Commands -

    [RelayCommand]
    private void EditItem(EntryTableView entry)
    {
        _entryFormPage.ViewModel.EditModel(new()
        {
            Model = entry,
            Title = "Edit Entry",
            MessengerToken = MessengerToken,
        });

        _navigationService.GetNavigationControl().Navigate(typeof(EntryFormPage));
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

    #endregion


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
        await _entryService.SaveEntryAsync((Entry)message.Value);
        _navigationService.GetNavigationControl().Navigate(typeof(EntriesPage));
    }
}
