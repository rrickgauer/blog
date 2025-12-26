using System.Data;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.Other;
using Blog.Service.Repository.Commands;
using Blog.Service.Repository.Contracts;
using Blog.Service.Repository.Other;
using Microsoft.Data.Sqlite;


namespace Blog.Service.Repository.Implementations;

public class EntryRepository(DatabaseConnection connection) : IEntryRepository
{
    private readonly DatabaseConnection _connection = connection;

    public async Task<DataTable> SelectAllAsync()
    {
        SqliteCommand command = new(EntryCommands.SelectAll);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }

    public async Task<int> UpdateEntryAsync(Entry entry)
    {
        SqliteCommand command = new(EntryCommands.Update);

        AddEntryParmsToCommand(command, entry);

        return await _connection.ModifyAsync(command);
    }

    public async Task<InsertAutoRowResult> InsertEntryAsync(Entry entry)
    {
        SqliteCommand command = new(EntryCommands.Insert);

        AddEntryParmsToCommand(command, entry);

        return await _connection.InsertAsync(command);
    }

    private static void AddEntryParmsToCommand(SqliteCommand command, Entry entry)
    {
        command.Parameters.AddWithValue("@id", entry.Id);
        command.Parameters.AddWithValue("@date", entry.Date);
        command.Parameters.AddWithValue("@title", entry.Title);
        command.Parameters.AddWithValue("@file_name", entry.FileName);
        command.Parameters.AddWithValue("@topic_id", entry.TopicId);
    }

    public async Task<int> DeleteEntryAsync(long entryId)
    {
        SqliteCommand command = new(EntryCommands.Delete);

        command.Parameters.AddWithValue("@id", entryId);

        return await _connection.ModifyAsync(command);
    }
}
