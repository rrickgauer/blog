using Blog.Service.Domain.TableView;
using Blog.Service.Repository.Contracts;
using Blog.Service.Services.Contracts;

namespace Blog.Service.Services.Implementations;

public class EntryService : IEntryService
{
    private readonly IEntryRepository _entryRepository;
    private readonly ITableMapperService _tableMapperService;

    public EntryService(IEntryRepository entryRepository, ITableMapperService tableMapperService)
    {
        _entryRepository = entryRepository;
        _tableMapperService = tableMapperService;
    }

    public async Task<IEnumerable<EntryTableView>> GetAllEntriesAsync()
    {
        var table = await _entryRepository.SelectAllAsync();

        var entries = _tableMapperService.ToModels<EntryTableView>(table);

        return entries;
    }

    public async Task<EntryTableView?> GetEntryAsync(uint entryId)
    {
        var entries = await GetAllEntriesAsync();

        var entry = entries.Where(e => e.EntryId == entryId).FirstOrDefault();

        return entry;
    }
}
