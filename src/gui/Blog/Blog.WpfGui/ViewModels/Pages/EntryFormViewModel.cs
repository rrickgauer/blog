using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.WpfGui.Helpers;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntryFormViewModel : ObservableObject, INavigationAware, IModelForm<EntryTableView>
{

    protected EntryTableView? _model = null;


    #region - Generated Properties -


    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private string _title = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private string _fileName = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private EntryTopic? _selectedTopic = null;

    [ObservableProperty]
    private ObservableCollection<EntryTopic> _topics = new(EntryTopic.GetAll());

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


    #region - IModelForm -


    public void EditModel(EntryTableView model)
    {
        _model = model;

        Title = model.Title ?? string.Empty;
        FileName = model.FileName ?? string.Empty;
        SelectedTopic = Topics.Where(t => t.Id == model.TopicId).FirstOrDefault();
    }


    public void NewModel()
    {
        
    }

    #endregion



    #region - Commands -

    [RelayCommand(CanExecute = nameof(CanSaveForm))]
    private async Task SaveFormAsync()
    {
        var tt = SelectedTopic;

        int x = 10;
    }


    private bool CanSaveForm()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(FileName))
        {
            return false;
        }

        if (SelectedTopic == null)
        {
            return false;
        }

        return true;
    }


    #endregion










}
