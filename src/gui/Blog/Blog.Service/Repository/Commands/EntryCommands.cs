namespace Blog.Service.Repository.Commands;

public sealed class EntryCommands
{
    public const string SelectAll = @"
        SELECT
            ve.id AS id,
            ve.date AS date,
            ve.date_formatted AS date_formatted,
            ve.title AS title,
            ve.file_name AS file_name,
            ve.topic_id AS topic_id,
            ve.topic_name AS topic_name
        FROM
            View_Entries ve
        ORDER BY
            ve.date DESC;
    ";

    public const string Update = @"
        UPDATE
            Entries
        SET
            date = @date,
            title = @title,
            file_name = @file_name,
            topic_id = @topic_id
        WHERE
            id = @id;
    ";


    public const string Insert = @"
        INSERT INTO
            Entries (id, date, title, file_name, topic_id)
        VALUES
            (@id, @date, @title, @file_name, @topic_id);
    ";
}
