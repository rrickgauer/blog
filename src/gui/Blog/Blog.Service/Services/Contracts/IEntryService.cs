using Blog.Service.Domain.TableView;

namespace Blog.Service.Services.Contracts;

public interface IEntryService
{
    public Task<IEnumerable<EntryTableView>> GetAllEntriesAsync();   
}
