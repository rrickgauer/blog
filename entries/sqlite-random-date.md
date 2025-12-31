To generate a random date in Sqlite between 1-1-2020 and 12-31-2025:

```sql
SELECT datetime(
  '2020-01-01 00:00:00',
  (ABS(RANDOM()) % CAST((julianday('2025-12-31') - julianday('2020-01-01'))*86400 AS INTEGER)) || ' seconds'
) AS random_datetime;
```