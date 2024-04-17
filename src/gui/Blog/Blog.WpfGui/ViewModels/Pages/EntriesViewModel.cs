using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.Views.Pages;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntriesViewModel(IEntryService entryService, EntryFormPage entryFormPage, INavigationService navigationService) : ObservableObject, INavigationAware
{
    private readonly IEntryService _entryService = entryService;
    private readonly EntryFormPage _entryFormPage = entryFormPage;
    private readonly INavigationService _navigationService = navigationService;

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

    public void OnNavigatedFrom()
    {

    }

    public async void OnNavigatedTo()
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
        _entryFormPage.ViewModel.EditModel(entry);
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





}
