using Blog.Service.Domain.Configs;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.WpfGui.Helpers;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;


public partial class EntryFormViewModel : ObservableObject, INavigationAware, IModelForm<EntryTableView>
{

    private readonly IConfigs _configs;


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
    private string _saveButtonText = string.Empty;

    [ObservableProperty]
    private string _cancelButtonText = string.Empty;



    [ObservableProperty]
    private ObservableCollection<EntryTopic> _topics = new(EntryTopic.GetAll());



    #endregion



    public EntryFormViewModel(IConfigs configs)
    {
        _configs = configs;
    }




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


    public void EditModel(EditModelFormArgs<EntryTableView> args)
    {
        _model = args.Model;

        Title = args.Model.Title ?? string.Empty;
        FileName = args.Model.FileName ?? string.Empty;
        SelectedTopic = Topics.Where(t => t.Id == args.Model.TopicId).FirstOrDefault();

        SaveButtonText = args.SaveButtonText;
        CancelButtonText = args.CancelButtonText;
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


    [RelayCommand]
    private void SelectFolder()
    {
        if (!TrySelectingEntryFile(out FileInfo? selectedFile))
        {
            return;
        }


        var fileName = selectedFile!.Name;

        int x = 10;


        
    }


    private bool TrySelectingEntryFile(out FileInfo? selectedFile)
    {
        OpenFileDialog dialog = new()
        {
            DefaultExt = ".md",
            Filter = "Markdown (.md)|*.md",
            Multiselect = false,
            InitialDirectory = _configs.EntryFilesPath,
            DefaultDirectory = _configs.EntryFilesPath,
        };

        selectedFile = null;

        if (dialog.ShowDialog() == true)
        {
            selectedFile = new(dialog.FileName);
            return true;
        }

        return false;
    }


    #endregion










}
