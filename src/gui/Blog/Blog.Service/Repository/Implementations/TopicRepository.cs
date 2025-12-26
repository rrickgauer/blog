using System.Data;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.Other;
using Blog.Service.Repository.Commands;
using Blog.Service.Repository.Contracts;
using Blog.Service.Repository.Other;
using Microsoft.Data.Sqlite;

namespace Blog.Service.Repository.Implementations;

public class TopicRepository(DatabaseConnection connection) : ITopicRepository
{
    private readonly DatabaseConnection _connection = connection;

    public async Task<DataTable> SelectAllUsedAsync()
    {
        SqliteCommand command = new(TopicCommands.SelectAllUsed);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }

    public async Task<DataTable> SelectAllAsync()
    {
        SqliteCommand command = new(TopicCommands.SelectAll);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }

    public async Task<int> UpdateTopicAsync(EntryTopic topic)
    {
        SqliteCommand command = new(TopicCommands.Update);

        AddModifyParms(topic, command);

        return await _connection.ModifyAsync(command);
    }

    public async Task<InsertAutoRowResult> InsertTopicAsync(EntryTopic topic)
    {
        SqliteCommand command = new(TopicCommands.Insert);

        AddModifyParms(topic, command);

        return await _connection.InsertAsync(command);
    }

    private void AddModifyParms(EntryTopic topic, SqliteCommand command)
    {
        command.Parameters.AddWithValue("@id", topic.Id);
        command.Parameters.AddWithValue("@name", topic.Name);
    }

    public async Task<int> DeleteTopicAsync(long topicId)
    {
        SqliteCommand command = new(TopicCommands.Delete);

        command.Parameters.AddWithValue("@id", topicId);

        return await _connection.ModifyAsync(command);
    }
}