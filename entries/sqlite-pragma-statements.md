These are some useful `PRAGMA` statements that I use for my SQLite databases:

```sql
PRAGMA foreign_keys = ON;
PRAGMA journal_mode = WAL;
PRAGMA synchronous = NORMAL;
PRAGMA recursive_triggers = ON;
PRAGMA strict = ON;
```

Note: These need to be set for *every* connection.
