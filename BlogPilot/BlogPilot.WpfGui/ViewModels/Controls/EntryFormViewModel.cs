using BlogPilot.Services.Domain.Enum;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Utilities;
using BlogPilot.WpfGui.Enums;
using BlogPilot.WpfGui.Other;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryFormViewModel : ObservableObject, IViewModelForm<Entry>
{


    #region - Generated Properties -

    /// <summary>
    /// Title
    /// </summary>
    [ObservableProperty]
    private string _title = string.Empty;

    /// <summary>
    /// Link
    /// </summary>
    [ObservableProperty]
    private string _link = string.Empty;

    /// <summary>
    /// Topics
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<TopicReference> _topics = new(EnumUtilities.ToCollection<TopicReference>());

    /// <summary>
    /// SelectedTopic
    /// </summary>
    [ObservableProperty]
    private TopicReference? _selectedTopic = null;

    #endregion


    public FormInputMode Mode { get; private set; } = FormInputMode.Create;


    public EntryFormViewModel(FormInputMode mode)
    {
        Mode = mode;
    }





    #region - IViewModelForm -
    public Entry GetFormInputValues()
    {
        throw new NotImplementedException();
    }

    public void SetFormInputValues(Entry model)
    {
        throw new NotImplementedException();
    }
    #endregion
}
