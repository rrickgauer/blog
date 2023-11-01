using System.Data;

namespace Blog.Service.Repository.Contracts;

public interface IEntryRepository
{
    public Task<DataTable> SelectAllAsync();
}
