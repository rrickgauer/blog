Today I published a python application called [sql-format](https://github.com/rrickgauer/sql-format) It's a simple SQL statement formatter. 

## Example

Let's say you have the following SQL statement:

```sql
select Songs.id, Songs.title, Artists.name from Songs left join Artists on Songs.artist_id = Artists.id where Songs.id > 100 order by Songs.title desc limit 20;
```

If you paste that into the textbox, its result would be:

```sql
SELECT Songs.id,
       Songs.title,
       Artists.name
FROM   Songs
       LEFT JOIN Artists
              ON Songs.artist_id = Artists.id
WHERE  Songs.id > 100
ORDER  BY Songs.title DESC
LIMIT  20;
```
