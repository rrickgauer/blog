using System.ComponentModel;

namespace Blog.Service.Repository.Other;

public enum SqliteConnectionPragma
{
    [Description("PRAGMA journal_mode = WAL;")]
    JournalMode,

    [Description("PRAGMA foreign_keys = ON;")]
    ForeignKeys,

    [Description("PRAGMA synchronous = NORMAL;")]
    Synchronous,

    [Description("PRAGMA busy_timeout = 5000;")]
    BusyTimeout,
}

public static class SqliteConnectionPragmaExtensions
{
    public static string GetSqlText(this SqliteConnectionPragma pragmas)
    {
        return AttributeUtility.GetDescription(pragmas);
    }
}


