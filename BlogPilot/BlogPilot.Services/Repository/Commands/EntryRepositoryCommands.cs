namespace BlogPilot.Services.Repository.Commands;

public static class EntryRepositoryCommands
{
    public const string SelectAll = @"
        SELECT
            *
        FROM
            View_Entries v
        ORDER BY
            v.date DESC;";

    public const string Insert = @"
        INSERT INTO
            Entries (date, title, link, topic_id)
        VALUES
            (@date, @title, @link, @topic_id);";
}
