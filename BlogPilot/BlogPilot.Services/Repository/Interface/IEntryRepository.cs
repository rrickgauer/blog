using System.Data;

namespace BlogPilot.Services.Repository.Interface;

public interface IEntryRepository
{
    public Task<DataTable> SelectAllAsync();
}
