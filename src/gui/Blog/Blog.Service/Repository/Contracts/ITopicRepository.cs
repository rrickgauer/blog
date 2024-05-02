using System.Data;

namespace Blog.Service.Repository.Contracts;

public interface ITopicRepository
{
    public Task<DataTable> SelectAllUsedAsync();
    public Task<DataTable> SelectAllAsync();
}
