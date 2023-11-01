using Blog.Service.Domain.Configs;
using MySql.Data.MySqlClient;
using System.Data;

namespace Blog.Service.Repository.Other;

public class DatabaseConnection
{
    private readonly IConfigs _configs;

    public string ConnectionString => $"server={_configs.DbServer};user={_configs.DbUser};database={_configs.DbDataBase};password={_configs.DbPassword}";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="configs"></param>
    public DatabaseConnection(IConfigs configs)
    {
        _configs = configs;
    }


    /// <summary>
    /// Fetch the first row from a data table (one result).
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<DataRow?> FetchAsync(MySqlCommand command)
    {
        var dataTable = await FetchAllAsync(command);

        DataRow? row = null;

        if (dataTable.Rows.Count > 0)
        {
            row = dataTable.Rows[0];
        }

        return row;
    }


    /// <summary>
    /// Retrieve all the data rows for the specified sql command
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<DataTable> FetchAllAsync(MySqlCommand command)
    {
        // setup a new database connection object
        using MySqlConnection connection = GetNewConnection();

        await connection.OpenAsync();

        command.Connection = connection;

        // fill the datatable with the command results
        DataTable results = await RepositoryUtils.LoadDataTableAsync(command);

        // close the connection
        await CloseConnectionAsync(connection);

        return results;
    }



    public async Task<bool> ModifyWithTransactionAsync(params MySqlCommand[] commands)
    {
        // setup a new database connection object
        using MySqlConnection connection = GetNewConnection();
        await connection.OpenAsync();

        // start up a transaction
        using MySqlTransaction transaction = await connection.BeginTransactionAsync();

        try
        {
            foreach (MySqlCommand command in commands)
            {
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
            }

            await transaction.CommitAsync();
            await transaction.DisposeAsync();
            await CloseConnectionAsync(connection);
        }

        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }

        return true;
    }




    /// <summary>
    /// Exeucte the specified sql command that modifies (insert, update, delete) data.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<int> ModifyAsync(MySqlCommand command)
    {
        // setup a new database connection object
        using MySqlConnection conn = GetNewConnection();
        await conn.OpenAsync();
        command.Connection = conn;

        // execute the non query command
        int numRowsAffected = await command.ExecuteNonQueryAsync();

        // close the connection
        await CloseConnectionAsync(conn);

        return numRowsAffected;
    }

    /// <summary>
    /// Get a new connection using the connection string
    /// </summary>
    /// <returns></returns>
    private MySqlConnection GetNewConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    private static async Task CloseConnectionAsync(MySqlConnection connection)
    {
        // close the connection
        await connection.CloseAsync();
        await connection.DisposeAsync();
    }
}


