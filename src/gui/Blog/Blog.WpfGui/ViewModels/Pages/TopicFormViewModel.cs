using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.TableView;
using Blog.WpfGui.ViewModels.Base;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui;
using Wpf.Ui.Controls;
using static Blog.WpfGui.Messenger.ViewMessages;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicFormViewModel(INavigationService navigationService) : ViewModel, IModelForm<TopicTableView>
{

    #region - Private Members -

    private readonly INavigationView _navigation = navigationService.GetNavigationControl();

    private Guid _parentMessengerToken = Guid.Empty;

    private TopicTableView _topic = new();

    protected TopicTableView Topic
    {
        get => _topic;
        set
        {
            _topic = value;
            NameInputText = _topic.Name ?? string.Empty;
        }
    }

    #endregion

    #region - Generated Properties -

    [ObservableProperty]
    private string _pageTitle = string.Empty;

    [ObservableProperty]
    private string _saveButtonText = string.Empty;

    [ObservableProperty]
    private string _cancelButtonText = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private string _nameInputText = string.Empty;

    #endregion

    #region - IModelForm -

    public void EditModel(EditModelFormArgs<TopicTableView> args)
    {
        HandleNewModelFormArgs(args);
        Topic = args.Model;
    }

    public void NewModel(NewModelFormArgs args)
    {
        HandleNewModelFormArgs(args);
        Topic = new();
    }

    #endregion

    #region - Commands -

    [RelayCommand(CanExecute = nameof(CanSaveForm))]
    private void SaveForm()
    {
        Topic.Name = NameInputText;

        WeakReferenceMessenger.Default.Send(new TopicFormSavedMessage(Topic), _parentMessengerToken);
    }

    private bool CanSaveForm()
    {
        if (string.IsNullOrWhiteSpace(NameInputText))
        {
            return false;
        }

        return true;
    }

    [RelayCommand]
    private void CloseForm()
    {
        _navigation.GoBack();
    }

    #endregion



    private void HandleNewModelFormArgs(NewModelFormArgs args)
    {
        PageTitle = args.Title;
        SaveButtonText = args.SaveButtonText;
        CancelButtonText = args.CancelButtonText;
        _parentMessengerToken = args.MessengerToken;
    }

}
