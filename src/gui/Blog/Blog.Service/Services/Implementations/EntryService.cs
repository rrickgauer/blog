using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Repository.Contracts;
using Blog.Service.Services.Contracts;

namespace Blog.Service.Services.Implementations;

public class EntryService(IEntryRepository entryRepository, ITableMapperService tableMapperService) : IEntryService
{
    private readonly IEntryRepository _entryRepository = entryRepository;
    private readonly ITableMapperService _tableMapperService = tableMapperService;

    public async Task<List<EntryTableView>> GetAllEntriesAsync()
    {
        var table = await _entryRepository.SelectAllAsync();

        var entries = _tableMapperService.ToModels<EntryTableView>(table);

        return entries;
    }

    public async Task<EntryTableView?> GetEntryAsync(uint entryId)
    {
        return await GetEntryAsync((int)entryId);
    }

    public async Task<EntryTableView?> GetEntryAsync(int entryId)
    {
        var entries = await GetAllEntriesAsync();

        var entry = entries.Where(e => e.EntryId == entryId).FirstOrDefault();

        return entry;
    }

    public async Task<EntryTableView?> SaveEntryAsync(Entry entry)
    {
        int entryId = await SaveEntryToRepoAsync(entry);

        return await GetEntryAsync(entryId);
    }

    /// <summary>
    /// Call appropriate repo method either save or insert the given Entry
    /// </summary>
    /// <param name="entry"></param>
    /// <returns>The entry id</returns>
    private async Task<int> SaveEntryToRepoAsync(Entry entry)
    {
        int entryId = 0;

        if (entry.Id.HasValue)
        {
            await _entryRepository.UpdateEntryAsync(entry);
            entryId = entry.Id.Value;
        }

        else
        {
            entryId = (await _entryRepository.InsertEntryAsync(entry)).RowId;
        }

        return entryId;
    }
}
