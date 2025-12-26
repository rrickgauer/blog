using Blog.Service.Domain.Model;
using Blog.Service.Domain.Other;
using System.Data;

namespace Blog.Service.Repository.Contracts;

public interface ITopicRepository
{
    public Task<DataTable> SelectAllUsedAsync();
    public Task<DataTable> SelectAllAsync();
    public Task<int> UpdateTopicAsync(EntryTopic topic);
    public Task<InsertAutoRowResult> InsertTopicAsync(EntryTopic topic);
    public Task<int> DeleteTopicAsync(long topicId);
}
