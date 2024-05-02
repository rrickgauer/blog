using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.TableView;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicFormViewModel : ObservableObject, INavigationAware, IModelForm<TopicTableView>
{


    [ObservableProperty]
    private string _pageTitle = string.Empty;



    #region - IModelForm -

    public void EditModel(EditModelFormArgs<TopicTableView> args)
    {
        PageTitle = args.Title;
    }

    public void NewModel(NewModelFormArgs args)
    {
        throw new NotImplementedException();
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
}
