using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntriesViewModel(IEntryService entryService) : ObservableObject, INavigationAware
{
    private readonly IEntryService _entryService = entryService;


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
        int x = 10;
    }

    [RelayCommand]
    private void DeleteEntry(EntryTableView entry)
    {
        int x = 10;
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


}
