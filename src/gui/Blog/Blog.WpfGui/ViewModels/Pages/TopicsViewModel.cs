using Blog.Service.Domain.TableView;
using Blog.Service.Services.Contracts;
using Blog.WpfGui.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class TopicsViewModel : NavigableViewModel
{
    private readonly ITopicService _topicService;

    [ObservableProperty]
    private ObservableCollection<TopicTableView> _topics = new();

    public TopicsViewModel(ITopicService topicService)
    {
        _topicService = topicService;

        InitMessenger();
    }


    public async override void OnNavigatedTo()
    {
        base.OnNavigatedTo();

        await RefreshTopics();
    }

    private async Task RefreshTopics()
    {
        var topics = await _topicService.GetAllTopicsAsync();
        Topics = new(topics);
    }
}
