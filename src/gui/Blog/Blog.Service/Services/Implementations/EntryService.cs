using Blog.Service.Domain.Configs;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using Blog.Service.Repository.Contracts;
using Blog.Service.Services.Contracts;
using System.Diagnostics;

namespace Blog.Service.Services.Implementations;

public class EntryService(IEntryRepository entryRepository, ITableMapperService tableMapperService, IConfigs configs) : IEntryService
{
    private readonly IEntryRepository _entryRepository = entryRepository;
    private readonly ITableMapperService _tableMapperService = tableMapperService;
    private readonly IConfigs _configs = configs;

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

    /// <summary>
    /// Open the published entry in web browser
    /// </summary>
    /// <param name="entryId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task ViewPublication(int entryId)
    {
        var entry = await GetEntryAsync(entryId);

        if (entry == null)
        {
            throw new Exception($"Entry does not exist with id: {entryId}");
        }

        string url = entry.GetPublicUrl(_configs);

        ProcessStartInfo startInfo = new(url)
        {
            UseShellExecute = true,
        };

        Process.Start(startInfo);
    }
}
