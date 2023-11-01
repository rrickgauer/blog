using System.Data;
using Blog.Service.Repository.Commands;
using Blog.Service.Repository.Contracts;
using Blog.Service.Repository.Other;
using MySql.Data.MySqlClient;

namespace Blog.Service.Repository.Implementations;

public class EntryRepository : IEntryRepository
{
    private readonly DatabaseConnection _connection;

    public EntryRepository(DatabaseConnection connection)
    {
        _connection = connection;
    }


    public async Task<DataTable> SelectAllAsync()
    {
        MySqlCommand command = new(EntryCommands.SelectAll);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }
}
