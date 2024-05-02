using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.ViewModels.Base;
using Blog.WpfGui.Views.Pages;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Wpf.Ui;
using static Blog.WpfGui.Messenger.ViewMessages;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicsViewModel : ViewModel,
    IRecipient<TopicFormSavedMessage>
{
    #region - Private Members -
    private readonly ITopicService _topicService;
    private readonly INavigationService _navigation;
    private readonly TopicFormViewModel _topicFormViewModel;
    #endregion

    #region - Generated Properties -

    [ObservableProperty]
    private ObservableCollection<TopicTableView> _topics = new();

    [ObservableProperty]
    private TopicTableView? _selectedTopic = null;

    partial void OnSelectedTopicChanged(TopicTableView? value)
    {
        int x = 10;
    }

    [ObservableProperty]
    private bool _showWaitIndicator = false;

    #endregion

    #region - Constructor -

    public TopicsViewModel(ITopicService topicService, INavigationService navigationService, TopicFormViewModel topicFormViewModel)
    {
        _topicService = topicService;
        _navigation = navigationService;
        _topicFormViewModel = topicFormViewModel;

        InitMessenger();
    }

    #endregion

    #region - Public Methods -
    public void OnRowSelected(TopicTableView topic)
    {
        _topicFormViewModel.EditModel(new()
        {
            MessengerToken = MessengerToken,
            Model = topic,
            Title = "Edit Topic",
            CancelButtonText = "Cancel",
            SaveButtonText = "Save",
        });

        _previouslySelectedTopicId = topic.TopicId;

        NavigateToFormPage();
    }

    public async override void OnNavigatedTo()
    {
        base.OnNavigatedTo();
        
        ShowWaitIndicator = true;

        await RefreshTopics();

        if (_previouslySelectedTopicId.HasValue)
        {
            SelectedTopic = Topics.FirstOrDefault(t => t.TopicId == _previouslySelectedTopicId);
        }

        ShowWaitIndicator = false;
    }

    #endregion

    #region - Messenger -


    private uint? _previouslySelectedTopicId = null;


    public async void Receive(TopicFormSavedMessage message)
    {
        await SaveTopicFormChangesAsync(message.Value);
        
        NavigateHere();
    }

    #endregion


    #region - Commands -

    [RelayCommand]
    private void NewTopic()
    {
        _topicFormViewModel.NewModel(new()
        {
            MessengerToken = MessengerToken,
            Title = "New Topic",
            CancelButtonText = "Cancel",
            SaveButtonText = "Create",
        });

        NavigateToFormPage();
    }

    #endregion



    #region - Private Methods -

    private void NavigateToFormPage()
    {
        _navigation.GetNavigationControl().Navigate(typeof(TopicFormPage));
    }

    private void NavigateHere()
    {
        _navigation.GetNavigationControl().Navigate(typeof(TopicsPage));
    }

    private async Task RefreshTopics()
    {
        var topics = await _topicService.GetAllTopicsAsync();
        Topics = new(topics);
    }


    private async Task SaveTopicFormChangesAsync(TopicTableView topic)
    {
        await _topicService.SaveTopicAsync((EntryTopic)topic);
    }

    #endregion
}
