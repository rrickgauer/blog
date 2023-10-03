using BlogPilot.WpfGui.Views.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.ViewModels.Pages;

public partial class CreateEntryViewModel : ObservableObject, INavigationAware
{
    #region - Generated Properties - 


    [ObservableProperty]
    private EntryFormControl _entryFormControl = new(new(Enums.FormInputMode.Create));

    #endregion

    #region - INavigationAware - 

    public void OnNavigatedFrom()
    {
        //throw new NotImplementedException();
    }

    public void OnNavigatedTo()
    {
        //throw new NotImplementedException();
    }

    #endregion
}
