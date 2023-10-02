using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Repository.Interface;
using BlogPilot.Services.Service.Interface;

namespace BlogPilot.Services.Service.Implementation;

public class EntryService : IEntryService
{
    #region - Private Members -
    private readonly IEntryRepository _entryRepository;
    private readonly IModelMapperService _mapperService;
    #endregion

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="entryRepository"></param>
    /// <param name="mapperService"></param>
    public EntryService(IEntryRepository entryRepository, IModelMapperService mapperService)
    {
        _entryRepository = entryRepository;
        _mapperService = mapperService;
    }


    public async Task<EntryTableView?> GetEntryAsync(int entryId)
    {
        var entries = await GetEntriesAsync();

        return entries.Where(e => e.Id == entryId).FirstOrDefault();
    }

    public async Task<IEnumerable<EntryTableView>> GetEntriesAsync()
    {
        var table = await _entryRepository.SelectAllAsync();

        return _mapperService.ToModels<EntryTableView>(table);
    }

    public async Task<EntryTableView> CreateEntryAsync(Entry entry)
    {
        var newEntryId = await _entryRepository.InsertAsync(entry);

        return await GetEntryAsync(newEntryId) ?? throw new ArgumentException("Could not create a new entry record");
    }

    public async Task<int> SaveEntryAsync(Entry entry)
    {
        return await _entryRepository.UpdateAsync(entry);
    }

    public async Task<int> DeleteEntryAsync(int entryId)
    {
        return await _entryRepository.DeleteAsync(entryId);
    }
}
