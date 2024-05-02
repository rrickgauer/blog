using Blog.Service.Domain.TableView;

namespace Blog.Service.Services.Contracts;

public interface ITopicService
{
    public Task<List<TopicTableView>> GetUsedTopicsAsync();
    public Task<List<TopicTableView>> GetAllTopicsAsync();
}