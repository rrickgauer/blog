using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Domain.TableViews;

namespace BlogPilot.Services.Service.Interface;

public interface IEntryService
{
    public Task<IEnumerable<EntryTableView>> GetEntriesAsync();
    public Task<EntryTableView?> GetEntryAsync(int entryId);
    public Task<EntryTableView> CreateEntryAsync(Entry entry);
    public Task<int> SaveEntryAsync(Entry entry);
    public Task<int> DeleteEntryAsync(int entryId);
}
