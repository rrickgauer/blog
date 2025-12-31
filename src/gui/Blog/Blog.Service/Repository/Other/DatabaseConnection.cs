using Blog.Service.Domain.Configs;
using Blog.Service.Domain.Other;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Blog.Service.Repository.Other;

public class DatabaseConnection(IConfigs configs)
{
    private readonly IConfigs _configs = configs;

    public string ConnectionString => $"server={_configs.DbServer};user={_configs.DbUser};database={_configs.DbDataBase};password={_configs.DbPassword}";

    private static SqliteConnectionPragma[] ConnectionPragmas => Enum.GetValues<SqliteConnectionPragma>();

    /// <summary>
    /// Fetch the first row from a data table (one result).
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<DataRow?> FetchAsync(SqliteCommand command)
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
    public async Task<DataTable> FetchAllAsync(SqliteCommand command)
    {
        // setup a new database connection object
        await using SqliteConnection connection = await GetNewConnection();

        await connection.OpenAsync();

        command.Connection = connection;

        // fill the datatable with the command results
        DataTable results = await RepositoryUtils.LoadDataTableAsync(command);

        // close the connection
        await CloseConnectionAsync(connection);

        return results;
    }



    public async Task<bool> ModifyWithTransactionAsync(params SqliteCommand[] commands)
    {
        // setup a new database connection object
        await using SqliteConnection connection = await GetNewConnection();
        await connection.OpenAsync();

        // start up a transaction
        using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync();

        try
        {
            foreach (SqliteCommand command in commands)
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
    public async Task<int> ModifyAsync(SqliteCommand command)
    {
        // setup a new database connection object
        await using SqliteConnection conn = await GetNewConnection();
        await conn.OpenAsync();
        command.Connection = conn;

        // execute the non query command
        int numRowsAffected = await command.ExecuteNonQueryAsync();

        // close the connection
        await CloseConnectionAsync(conn);

        return numRowsAffected;
    }

    public async Task<InsertAutoRowResult> InsertAsync(SqliteCommand command)
    {
        // setup a new database connection object
        await using SqliteConnection conn = await GetNewConnection();

        await conn.OpenAsync();
        command.Connection = conn;

        // execute the non query command
        int numRowsAffected = await command.ExecuteNonQueryAsync();

        // get the row id
        command.CommandText = "SELECT last_insert_rowid();";
        var lastId = await command.ExecuteScalarAsync();

        // close the connection
        await CloseConnectionAsync(conn);

        return new()
        {
            RowId = (long)lastId!,
            NumRows = numRowsAffected,
        };
        
    }
    private async Task<SqliteConnection> GetNewConnection()
    {
        SqliteConnection connection = new();

        SqliteConnectionStringBuilder sb = new()
        {
            DataSource = _configs.DatabaseFile,
            ForeignKeys = true,
            RecursiveTriggers = true,
            Mode = SqliteOpenMode.ReadWrite,
        };

        connection.ConnectionString = sb.ToString();

        await connection.OpenAsync();

        var pragmaCommand = GetPragmaCommand();
        pragmaCommand.Connection = connection;
        await pragmaCommand.ExecuteNonQueryAsync();

        return connection;
    }

    private static SqliteCommand GetPragmaCommand()
    {
        StringBuilder sb = new();

        foreach (var pragma in ConnectionPragmas)
        {
            sb.AppendLine(pragma.GetSqlText());
        }

        return new()
        {
            CommandText = sb.ToString(),
        };
    }

    private static async Task CloseConnectionAsync(SqliteConnection connection)
    {
        // close the connection

        string sql = @"
            PRAGMA wal_checkpoint(FULL);
            PRAGMA journal_mode = DELETE;";

        using SqliteCommand command = new(sql);

        command.Connection = connection;
        await command.ExecuteNonQueryAsync();

        await connection.CloseAsync();
        await connection.DisposeAsync();
    }
}




