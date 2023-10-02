using BlogPilot.Services.Domain.Model;
using System.Data;

namespace BlogPilot.Services.Repository.Interface;

public interface IEntryRepository
{
    public Task<DataTable> SelectAllAsync();

    public Task<int> InsertAsync(Entry entry);
    public Task<int> UpdateAsync(Entry entry);
    public Task<int> DeleteAsync(int entryId);
}
