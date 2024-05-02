namespace Blog.Service.Repository.Commands;

public sealed class TopicCommands
{
    public const string SelectAllUsed = @"
        SELECT
            *
        FROM
            View_Topics v
        WHERE 
            v.count_entries > 0
        ORDER BY
            v.topic_name ASC;";


    public const string SelectAll = @"
        SELECT
            *
        FROM
            View_Topics t
        ORDER BY
            t.topic_name ASC;";


    public const string Insert = @"
        INSERT INTO
            Topics (id, name)
        VALUES
            (@id, @name);";

    public const string Update = @"
        UPDATE
            Topics
        SET
            name = @name
        WHERE
            id = @id;";
    
}
