using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.TableView;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicFormViewModel(INavigationService navigationService) : ObservableObject, INavigationAware, IModelForm<TopicTableView>
{

    private readonly INavigationView _navigation = navigationService.GetNavigationControl();

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
        NameInputText = args.Model.Name ?? string.Empty;
    }

    public void NewModel(NewModelFormArgs args)
    {
        HandleNewModelFormArgs(args);
    }

    #endregion

    #region - INavigationAware -

    public void OnNavigatedFrom()
    {
        
    }

    public void OnNavigatedTo()
    {
        
    }

    #endregion


    #region - Commands -

    [RelayCommand(CanExecute = nameof(CanSaveForm))]
    private void SaveForm()
    {

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
    }

}
