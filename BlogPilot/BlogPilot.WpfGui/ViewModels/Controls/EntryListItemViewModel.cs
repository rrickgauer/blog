using BlogPilot.Services.Domain.TableViews;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryListItemViewModel : ObservableObject
{
    public EntryTableView Entry { get; private set; }

    public EntryListItemViewModel(EntryTableView entry)
    {
        Entry = entry;
    }

    #region - Commands -

    [RelayCommand]
    private void Edit()
    {
        int x = 10;
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
