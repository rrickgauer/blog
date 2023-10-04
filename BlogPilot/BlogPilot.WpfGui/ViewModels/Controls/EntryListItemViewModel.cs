using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Service.Interface;
using BlogPilot.WpfGui.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryListItemViewModel : ObservableObject
{
    private readonly IEntryService _entryService = App.GetService<IEntryService>();
    private readonly IWebService _webService = App.GetService<IWebService>();

    public EntryTableView Entry { get; private set; }

    [ObservableProperty]
    private bool _visibile = true;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="entry"></param>
    public EntryListItemViewModel(EntryTableView entry)
    {
        Entry = entry;
    }

    #region - Messaging -



    #endregion

    #region - Commands -

    /// <summary>
    /// EditCommand
    /// </summary>
    [RelayCommand]
    private void Edit()
    {
        WeakReferenceMessenger.Default.Send(new EntryListItemEditMessage(Entry.Id.Value));
    }

    /// <summary>
    /// DeleteCommand
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task DeleteAsync()
    {
        bool deleted = await DeleteEntryAsync();

        if (deleted)
        {
            WeakReferenceMessenger.Default.Send(new EntryListItemDeletedMessage(Entry.Id.Value));
        }
    }

    /// <summary>
    /// ViewCommand
    /// </summary>
    [RelayCommand]  
    private void View()
    {
        _webService.ViewEntry(Entry.Id.Value);
    }


    #endregion



    #region - Private Methods - 


    private async Task<bool> DeleteEntryAsync()
    {
        if (ConfirmDelete())
        {
            await _entryService.DeleteEntryAsync(Entry.Id.Value);
            return true;
        }

        return false;
    }

    private bool ConfirmDelete()
    {
        var response = MessageBox.Show("Are you sure you want to delete this entry?", "Delete entry", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

        switch (response)
        {
            case MessageBoxResult.Yes:
            case MessageBoxResult.OK:
                return true;
            default:
                return false;
        }
    }



    #endregion


}
