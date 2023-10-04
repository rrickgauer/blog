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


    public const string Update = @"
        UPDATE
            Entries
        SET
            title = @title,
            link = @link,
            topic_id = @topic_id
        WHERE
            id = @id;";


    public const string Delete = @"
        DELETE FROM
            Entries
        WHERE
            id = @id;";




}
