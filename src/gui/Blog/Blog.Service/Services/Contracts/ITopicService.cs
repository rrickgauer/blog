using Blog.Service.Domain.TableView;

namespace Blog.Service.Services.Contracts;

public interface ITopicService
{
    public Task<IEnumerable<TopicTableView>> GetUsedTopicsAsync();
}