using BlogPilot.Services.Domain.Model;
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

    public async Task<int> InsertAsync(Entry entry)
    {
        MySqlCommand command = new(EntryRepositoryCommands.Insert);

        command.Parameters.AddWithValue("@file_name", entry.FileName);
        command.Parameters.AddWithValue("@title", entry.Title);
        command.Parameters.AddWithValue("@topic_id", entry.TopicId);
        command.Parameters.AddWithValue("@date", entry.Date);

        return await _connection.InsertAsync(command);
    }

    public async Task<int> UpdateAsync(Entry entry)
    {
        MySqlCommand command = new(EntryRepositoryCommands.Update);

        command.Parameters.AddWithValue("@id", entry.Id);
        command.Parameters.AddWithValue("@title", entry.Title);
        command.Parameters.AddWithValue("@file_name", entry.FileName);
        command.Parameters.AddWithValue("@topic_id", entry.TopicId);

        return await _connection.ModifyAsync(command);
    }

    public async Task<int> DeleteAsync(int entryId)
    {
        MySqlCommand command = new(EntryRepositoryCommands.Delete);

        command.Parameters.AddWithValue("@id", entryId);

        return await _connection.ModifyAsync(command);
    }
}
