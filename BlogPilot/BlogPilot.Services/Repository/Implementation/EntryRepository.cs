using BlogPilot.Services.Repository.Commands;
using BlogPilot.Services.Repository.Interface;
using BlogPilot.Services.Repository.Other;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlogPilot.Services.Repository.Implementation;

public class EntryRepository : IEntryRepository
{

    private readonly DbConnection _connection;

    public EntryRepository(DbConnection connection)
    {
        _connection = connection;
    }
    


    public async Task<DataTable> SelectAllAsync()
    {
        MySqlCommand command = new(EntryRepositoryCommands.SelectAll);
        return await _connection.FetchAllAsync(command);
    }
}
