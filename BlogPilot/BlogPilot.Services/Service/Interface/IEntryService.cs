using BlogPilot.Services.Domain.TableViews;

namespace BlogPilot.Services.Service.Interface;

public interface IEntryService
{
    public Task<IEnumerable<EntryTableView>> GetEntriesAsync();
    public Task<EntryTableView?> GetEntryAsync(int entryId);
}
