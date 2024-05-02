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

    private uint? _previouslySelectedTopicId = null;
    #endregion

    #region - Events -
    public event EventHandler<TopicTableView>? ScrollToItem;
    #endregion

    #region - Generated Properties -

    [ObservableProperty]
    private ObservableCollection<TopicTableView> _topics = new();

    [ObservableProperty]
    private TopicTableView? _selectedTopic = null;

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

        NavigateToFormPage();
    }

    public async override void OnNavigatedTo()
    {
        base.OnNavigatedTo();
        
        ShowWaitIndicator = true;

        await RefreshTopics();
        RestorePreviouslySelectedTopic();

        ShowWaitIndicator = false;
    }

    public override void OnNavigatedFrom()
    {
        base.OnNavigatedFrom();

        _previouslySelectedTopicId = SelectedTopic?.TopicId;
    }

    #endregion

    #region - Messenger -


    


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

    private void RestorePreviouslySelectedTopic()
    {
        // if we have a topic that was previously selected, scroll down to it
        if (_previouslySelectedTopicId.HasValue)
        {
            SelectedTopic = Topics.FirstOrDefault(t => t.TopicId == _previouslySelectedTopicId);
            ScrollToItem?.Invoke(this, SelectedTopic!);
        }
    }

    #endregion
}
