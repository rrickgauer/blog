using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.ViewModels.Base;
using Blog.WpfGui.Views.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicsViewModel : NavigableViewModel
{
    private readonly ITopicService _topicService;
    private readonly INavigationService _navigation;
    private readonly TopicFormViewModel _topicFormViewModel;

    [ObservableProperty]
    private ObservableCollection<TopicTableView> _topics = new();

    public TopicsViewModel(ITopicService topicService, INavigationService navigationService, TopicFormViewModel topicFormViewModel)
    {
        _topicService = topicService;
        _navigation = navigationService;
        _topicFormViewModel = topicFormViewModel;

        InitMessenger();
    }

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

        await RefreshTopics();
    }

    private void NavigateToFormPage()
    {
        _navigation.GetNavigationControl().Navigate(typeof(TopicFormPage));
    }

    private async Task RefreshTopics()
    {
        var topics = await _topicService.GetAllTopicsAsync();
        Topics = new(topics);
    }
}
