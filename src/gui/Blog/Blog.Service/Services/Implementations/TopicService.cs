using Blog.Service.Domain.TableView;
using Blog.Service.Repository.Contracts;
using Blog.Service.Services.Contracts;

namespace Blog.Service.Services.Implementations;

public class TopicService(ITopicRepository topicRepository, ITableMapperService tableMapperService) : ITopicService
{
    private readonly ITopicRepository _topicRepository = topicRepository;
    private readonly ITableMapperService _tableMapperService = tableMapperService;

    public async Task<IEnumerable<TopicTableView>> GetUsedTopicsAsync()
    {
        var dataTable = await _topicRepository.SelectAllUsedAsync();

        var usedTopics = _tableMapperService.ToModels<TopicTableView>(dataTable);

        return usedTopics;
    }
}
