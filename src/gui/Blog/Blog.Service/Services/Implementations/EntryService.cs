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

    public async Task<EntryTableView?> GetEntryAsync(long entryId)
    {
        var entries = await GetAllEntriesAsync();

        var entry = entries.Where(e => e.EntryId == entryId).FirstOrDefault();

        return entry;
    }

    public async Task<EntryTableView?> SaveEntryAsync(Entry entry)
    {
        var entryId = await SaveEntryToRepoAsync(entry);

        return await GetEntryAsync(entryId);
    }

    /// <summary>
    /// Call appropriate repo method either save or insert the given Entry
    /// </summary>
    /// <param name="entry"></param>
    /// <returns>The entry id</returns>
    private async Task<long> SaveEntryToRepoAsync(Entry entry)
    {
        long entryId = 0;

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

    

    
    public async Task<int> DeleteEntryAsync(long entryId)
    { 
        return await _entryRepository.DeleteEntryAsync(entryId);
    }
}
