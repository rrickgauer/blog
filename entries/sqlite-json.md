To return a list of json objects as a single column using a subquery in SQLite: 

```sql
SELECT 
    l.id          AS log_id,
    l.message     AS log_message,
    l.occured_on  AS log_occured_on,
    l.created_on  AS log_created_on,
    (
        SELECT json_group_array(
            json_object(
                'id', t.id,
                'name', t.name,
                'color', t.color
            )
        )
        FROM log_tags lt
        JOIN view_tags t ON t.id = lt.tag_id
        WHERE lt.log_id = l.id
    ) AS assigned_tags
FROM logs l;
```

See https://sqlite.org/json1.html