To do an `UPSERT` statement in SQLite:

```sql
INSERT INTO log_tags (log_id, tag_id)
VALUES (2, 2)
ON CONFLICT (log_id, tag_id)
DO UPDATE SET log_id = excluded.log_id;
```

[Official documentation](https://sqlite.org/lang_upsert.html)