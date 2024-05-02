using System.Data;
using Blog.Service.Repository.Commands;
using Blog.Service.Repository.Contracts;
using Blog.Service.Repository.Other;
using MySql.Data.MySqlClient;

namespace Blog.Service.Repository.Implementations;

public class TopicRepository(DatabaseConnection connection) : ITopicRepository
{
    private readonly DatabaseConnection _connection = connection;

    public async Task<DataTable> SelectAllUsedAsync()
    {
        MySqlCommand command = new(TopicCommands.SelectAllUsed);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }

    public async Task<DataTable> SelectAllAsync()
    {
        MySqlCommand command = new(TopicCommands.SelectAll);

        var table = await _connection.FetchAllAsync(command);

        return table;
    }
}