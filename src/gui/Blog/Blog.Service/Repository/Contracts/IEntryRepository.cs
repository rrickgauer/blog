using Blog.Service.Domain.Model;
using Blog.Service.Domain.Other;
using System.Data;

namespace Blog.Service.Repository.Contracts;

public interface IEntryRepository
{
    public Task<DataTable> SelectAllAsync();
    public Task<InsertAutoRowResult> InsertEntryAsync(Entry entry);
    public Task<int> UpdateEntryAsync(Entry entry);
}


