using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Service.Interface;
using BlogPilot.WpfGui.Views.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.ViewModels.Pages;

public partial class EntriesViewModel : ObservableObject, INavigationAware
{
    #region - Private Members -
    private readonly IEntryService _entryService;
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


    public EntriesViewModel(IEntryService entryService)
    {
        _entryService = entryService;
    }

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
        
        var entries = await _entryService.GetEntriesAsync();
        var controls = entries.Select(e => new EntryListItemControl(new(e)));
        Entries = new(controls);
        
        SpinnerIsVisible = false;
    }


    #endregion
}
