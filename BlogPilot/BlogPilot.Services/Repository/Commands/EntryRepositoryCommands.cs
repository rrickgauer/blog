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
            Entries (file_name, title, topic_id, date)
        VALUES
            (@file_name, @title, @topic_id, @date);";


    public const string Update = @"
        UPDATE
            Entries
        SET
            title = @title,
            file_name = @file_name,
            topic_id = @topic_id
        WHERE
            id = @id;";


    public const string Delete = @"
        DELETE FROM
            Entries
        WHERE
            id = @id;";




}
