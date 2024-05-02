﻿using Blog.Service.Domain.Configs;
using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.ViewModels.Base;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using Wpf.Ui;
using Wpf.Ui.Controls;
using static Blog.WpfGui.Messenger.ViewMessages;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class EntryFormViewModel : ViewModel, IModelForm<EntryTableView>
{
    #region - Private Members -
    private readonly IConfigs _configs;
    private readonly IEntryService _entryService;
    private readonly INavigationView _navigation;
    private readonly ITopicService _topicService;


    protected EntryTableView? _entryTableView = null;

    protected EntryTableView? EntryTableView
    {
        get => _entryTableView;
        set
        {
            if (value is null)
            {
                SetFormValues(new());
            }
            else
            {
                SetFormValues(value);
            }

            _entryTableView = value;
        }
    }

    private Guid _parentMessengerToken = Guid.Empty;

    #endregion

    #region - Generated Properties -

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private string _title = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private string _fileName = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveFormCommand))]
    private TopicTableView? _selectedTopic = null;

    [ObservableProperty]
    private string _saveButtonText = string.Empty;

    [ObservableProperty]
    private string _cancelButtonText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<TopicTableView> _topics = new();

    [ObservableProperty]
    private string _formTitle = string.Empty;

    #endregion

    #region - Constructor -

    public EntryFormViewModel(IConfigs configs, IEntryService entryService, INavigationService navigationService, ITopicService topicService)
    {
        _configs = configs;
        _entryService = entryService;
        _topicService = topicService;
        _navigation = navigationService.GetNavigationControl();
    }

    #endregion

    #region - INavigationAware -

    public async override void OnNavigatedTo()
    {
        base.OnNavigatedTo();

        var topics = await _topicService.GetAllTopicsAsync();

        Topics = new(topics);

        if (EntryTableView?.TopicId is uint topicId)
        {
            SelectedTopic = Topics.Where(t => t.TopicId == topicId).FirstOrDefault();
        }
    }



    #endregion

    #region - IModelForm -

    public void EditModel(EditModelFormArgs<EntryTableView> args)
    {
        ProcessNewEntryFormArgs(args);

        EntryTableView = args.Model;

        Title = args.Model.Title ?? string.Empty;
        FileName = args.Model.FileName ?? string.Empty;

        

    }

    public void NewModel(NewModelFormArgs args)
    {
        ProcessNewEntryFormArgs(args);

        EntryTableView = new();
    }



    private void ProcessNewEntryFormArgs(NewModelFormArgs args)
    {
        SaveButtonText = args.SaveButtonText;
        CancelButtonText = args.CancelButtonText;

        _parentMessengerToken = args.MessengerToken;

        FormTitle = args.Title;
    }


    #endregion

    #region - Commands -

    [RelayCommand(CanExecute = nameof(CanSaveForm))]
    private void SaveForm()
    {
        if (EntryTableView is null)
        {
            return;
        }

        SetModelValues(EntryTableView);

        WeakReferenceMessenger.Default.Send(new EntryFormSavedMessage(EntryTableView), _parentMessengerToken);
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
    private void CloseForm()
    {
        _navigation.GoBack();
    }

    [RelayCommand]
    private void SelectFile()
    {
        if (TrySelectingEntryFile(out FileInfo? selectedFile))
        {
            FileName = selectedFile!.Name;
        }
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

    #region - Private Methods -

    private void SetModelValues(EntryTableView model)
    {
        model.Title = Title;
        model.FileName = FileName;
        model.TopicId = SelectedTopic?.TopicId;
    }

    private void SetFormValues(EntryTableView model)
    {
        Title = model.Title ?? string.Empty;
        FileName = model.FileName ?? string.Empty;
        SelectedTopic = Topics.Where(t => t.TopicId == model.TopicId).FirstOrDefault();
    }

    #endregion
}
