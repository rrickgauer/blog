using BlogPilot.Services.Domain.Enum;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Utilities;
using BlogPilot.WpfGui.Enums;
using BlogPilot.WpfGui.Messaging;
using BlogPilot.WpfGui.Other;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryFormViewModel : ObservableObject, IViewModelForm<Entry>
{

    #region - Symbolic Constants -
    private const string SubmitButtonTextValueCreate = "Create entry";
    private const string SubmitButtonTextValueEdit = "Save";
    #endregion

    #region - Private Members -

    private readonly Guid _messengerToken;

    private Entry _entry = new();

    #endregion

    #region - Generated Properties -

    /// <summary>
    /// Title
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private string _title = string.Empty;

    /// <summary>
    /// Link
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
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
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private TopicReference? _selectedTopic = null;

    /// <summary>
    /// SubmitButtonText
    /// </summary>
    [ObservableProperty]
    private string _submitButtonText = SubmitButtonTextValueCreate;

    /// <summary>
    /// CancelButtonText
    /// </summary>
    [ObservableProperty]    
    private string _cancelButtonText = "Cancel";

    #endregion


    #region - Public Properties -

    private FormInputMode _mode = FormInputMode.Create;

    public FormInputMode Mode
    {
        get => _mode;
        private set
        {
            _mode = value;
            UpdateSubmitButtonText(value);
        }
    }

    #endregion


    public EntryFormViewModel(FormInputMode mode, Guid messengerToken)
    {
        Mode = mode;
        _messengerToken = messengerToken;
    }


    #region - IViewModelForm -

    /// <summary>
    /// Copy the form input values into a new domain model
    /// </summary>
    /// <returns></returns>
    public Entry GetFormInputValues()
    {
        _entry.Title = Title;
        _entry.Link = new(Link);
        _entry.TopicId = (uint?)SelectedTopic;

        return _entry;


    }

    /// <summary>
    /// Set the form input values from the model values
    /// </summary>
    /// <param name="model"></param>
    public void SetFormInputValues(Entry model)
    {
        _entry = model;

        Title = _entry.Title ?? Title;
        Link = _entry.Link?.AbsoluteUri ?? Link;
        SelectedTopic = Topics.ToList().Where(t => (uint)t == _entry.TopicId).FirstOrDefault();
    }

    #endregion


    #region - Commands -

    /// <summary>
    /// SubmitCommand
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private void Submit()
    {
        WeakReferenceMessenger.Default.Send(new EntryFormSubmittedMessage(EventArgs.Empty), _messengerToken);
    }

    /// <summary>
    /// Can execute for SubmitCommand
    /// </summary>
    /// <returns></returns>
    private bool CanSubmit()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            return false;
        }
        else if (string.IsNullOrWhiteSpace(Link))
        {
            return false;
        }
        else if (SelectedTopic == null)
        {
            return false;
        }

        return true;
    }


    #endregion

    #region - Private Methods -

    /// <summary>
    /// Update the submit button form text based on the specific input mode
    /// </summary>
    /// <param name="mode"></param>
    private void UpdateSubmitButtonText(FormInputMode mode)
    {
        SubmitButtonText = mode switch
        {
            FormInputMode.Create => SubmitButtonTextValueCreate,
            _                    => SubmitButtonTextValueEdit,
        };
    }


    #endregion
}
