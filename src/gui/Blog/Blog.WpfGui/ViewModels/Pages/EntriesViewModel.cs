using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntriesViewModel : ObservableObject, INavigationAware
{
    private readonly IEntryService _entryService;

    public EntriesViewModel(IEntryService entryService)
    {
        _entryService = entryService;
        
    }



    #region - Generated Properties -

    /// <summary>
    /// Entries
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<EntryTableView> _entries = new();

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
        var entries = await _entryService.GetAllEntriesAsync();
        Entries = new(entries);
    }


    #endregion



}
