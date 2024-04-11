using Blog.Service.Domain.TableView;

namespace Blog.Service.Services.Contracts;

public interface IEntryService
{
    public Task<List<EntryTableView>> GetAllEntriesAsync();
    public Task<EntryTableView?> GetEntryAsync(uint entryId);
}
