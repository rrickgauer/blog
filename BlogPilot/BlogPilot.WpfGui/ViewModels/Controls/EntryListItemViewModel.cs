using BlogPilot.Services.Domain.TableViews;
using BlogPilot.WpfGui.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryListItemViewModel : ObservableObject
{
    public EntryTableView Entry { get; private set; }

    public EntryListItemViewModel(EntryTableView entry)
    {
        Entry = entry;
    }


    #region - Messaging -



    #endregion


    #region - Commands -

    [RelayCommand]
    private void Edit()
    {
        int x = 10;

        WeakReferenceMessenger.Default.Send(new EntryListItemEditMessage(Entry.Id.Value));
    }

    [RelayCommand]
    private void Delete()
    {
        int x = 10;
    }

    [RelayCommand]  
    private void View()
    {
        int x = 10;
    }


    #endregion
}
