using BlogPilot.Services.Configs;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BlogPilot.Services.Repository.Other;

public static class RepositoryUtils
{
    public static MySqlConnection GetConnection(IConfigs configs)
    {
        string connectionString = GetConnectionString(configs);
        MySqlConnection conn = new(connectionString);
        return conn;
    }

    public static string GetConnectionString(IConfigs configs)
    {
        return $"server={configs.DbServer};user={configs.DbUser};database={configs.DbDataBase};password={configs.DbPassword}";
    }

    public static async Task<DataTable> LoadDataTableAsync(MySqlCommand command)
    {
        DataTable dataTable = new();

        DbDataReader reader = await command.ExecuteReaderAsync();
        dataTable.Load(reader);

        return dataTable;
    }
}
