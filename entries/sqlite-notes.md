
## Content

<details open>

<summary>Click to expand</summary>

1. [Useful Pragma Statements](#useful-pragma-statements)
1. [Upsert](#upsert)
1. [Generate Random DateTimes](#generate-random-datetime)
1. [JSON](#json)
1. [Text Ordering](#text-ordering)

</details>


## Useful Pragma Statements

These are some useful `PRAGMA` statements that I use for my SQLite databases:

```sql
PRAGMA foreign_keys = ON;
PRAGMA journal_mode = WAL;
PRAGMA synchronous = NORMAL;
PRAGMA recursive_triggers = ON;
PRAGMA strict = ON;
PRAGMA compile_options = ENABLE_JSON1;
```

Note: These need to be set for *every* connection.

Docs: https://www.sqlite.org/pragma.html

## Upsert

To do an `UPSERT` statement in SQLite:

```sql
INSERT INTO log_tags (log_id, tag_id)
VALUES (2, 2)
ON CONFLICT (log_id, tag_id)
DO UPDATE SET log_id = excluded.log_id;
```

Docs: https://sqlite.org/lang_upsert.html

## Generate Random DateTime

To generate a random date in Sqlite between 1-1-2020 and 12-31-2025:

```sql
SELECT datetime(
  '2020-01-01 00:00:00',
  (ABS(RANDOM()) % CAST((julianday('2025-12-31') - julianday('2020-01-01'))*86400 AS INTEGER)) || ' seconds'
) AS random_datetime;
```

Docs: https://sqlite.org/lang_datefunc.html

## JSON

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

Docs https://sqlite.org/json1.html


## Text Ordering

In SQLite, text column ordering is case sensitive.

To order a text column ignoring case:

```sql
SELECT *
FROM my_table
ORDER BY my_column COLLATE NOCASE {ASC,DESC};
```

### Persistence

You can define a column with `NOCASE`:

```sql
CREATE TABLE my_table (
    my_column TEXT COLLATE NOCASE
);
```

Also, you can define an index with `NOCASE`:

```sql
CREATE INDEX idx_my_column_nocase 
ON my_table(my_column COLLATE NOCASE);
```

Now, you don't have to add the `COLLATE NOCASE` to queries to order a column ignoring case:

```sql
SELECT *
FROM my_table
ORDER BY my_column DESC;
```

Docs: https://www.sqlite.org/lang_expr.html#collateop









