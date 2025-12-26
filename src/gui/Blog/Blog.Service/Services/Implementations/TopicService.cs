using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Repository.Contracts;
using Blog.Service.Services.Contracts;

namespace Blog.Service.Services.Implementations;

public class TopicService(ITopicRepository topicRepository, ITableMapperService tableMapperService) : ITopicService
{
    private readonly ITopicRepository _topicRepository = topicRepository;
    private readonly ITableMapperService _tableMapperService = tableMapperService;

    public async Task<List<TopicTableView>> GetUsedTopicsAsync()
    {
        var dataTable = await _topicRepository.SelectAllUsedAsync();

        var usedTopics = _tableMapperService.ToModels<TopicTableView>(dataTable);

        return usedTopics;
    }

    public async Task<List<TopicTableView>> GetAllTopicsAsync()
    {
        var dataTable = await _topicRepository.SelectAllAsync();

        var usedTopics = _tableMapperService.ToModels<TopicTableView>(dataTable);

        return usedTopics;
    }

    public async Task<TopicTableView> SaveTopicAsync(EntryTopic topic)
    {
        var topicId = await SaveTopicInRepoAsync(topic);

        return await GetTopicAsync(topicId);
    }


    private async Task<long> SaveTopicInRepoAsync(EntryTopic topic)
    {
        if (topic.Id.HasValue)
        {
            await _topicRepository.UpdateTopicAsync(topic);
            return topic.Id.Value;
        }
        else
        {
            var insertResult = await _topicRepository.InsertTopicAsync(topic);
            return (uint)insertResult.RowId;
        }
    }



    private async Task<TopicTableView> GetTopicAsync(long topicId)
    {
        var topics = await GetAllTopicsAsync();

        return topics.First(t => t.TopicId == topicId);
    }


    public async Task<bool> DeleteTopicAsync(long topicId)
    {
        var canDelete = await CanDeleteTopicAsync(topicId);

        if (canDelete)
        {
            await _topicRepository.DeleteTopicAsync(topicId);
        }

        return canDelete;
    }

    private async Task<bool> CanDeleteTopicAsync(long topicId)
    {
        var topic = await GetTopicAsync(topicId);

        long count = topic.Count ?? 0;

        if (count > 0)
        {
            return false;
        }

        return true;
    }
}
