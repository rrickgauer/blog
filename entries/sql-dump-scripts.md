This is how I make backups of my databases. I usually store the `dump.sql` file into source control. That way, I can see the changes I made to it.


### Postgres

```sh
set SCHEMA_FILE=C:\xampp\htdocs\files\tabulasync\sql\ddl\.schemas.sql
set DATA_FILE=C:\xampp\htdocs\files\tabulasync\sql\ddl\.data.sql
set IP_ADDRESS=000.000.000.000

pg_dump -U public_user -h %IP_ADDRESS% -F p --no-owner --no-comments --no-tablespaces --schema-only --file="%SCHEMA_FILE%" --dbname=database_name

pg_dump -U public_user -h %IP_ADDRESS% ^
--no-owner ^
--no-comments ^
--no-tablespaces ^
--data-only ^
--no-comments ^
--inserts ^
--disable-triggers ^
--dbname=database_name ^
--table=error_message_groups ^
--table=error_messages ^
--table=checklist_types ^
--table=event_frequencies ^
--table=event_action_types ^
--table=label_types ^
--table=color_names ^
--table=search_item_types ^
--table=comment_types ^
--file="%DATA_FILE%"

@echo off
cd "C:\xampp\htdocs\files\tabulasync\sql\ddl"
type "%SCHEMA_FILE%" "%DATA_FILE%" > "dump.sql"
del "%SCHEMA_FILE%" /Q
del "%DATA_FILE%" /Q

pause
```


### SQLite

```sh
@echo off

set DB_FILE=C:\path\to\tabulasync.db
set SCHEMA_FILE=C:\xampp\htdocs\files\tabulasync\sql\ddl\.schemas.sql
set DATA_FILE=C:\xampp\htdocs\files\tabulasync\sql\ddl\.data.sql

:: ===============================
:: Dump schema only
:: ===============================
sqlite3 "%DB_FILE%" ".schema" > "%SCHEMA_FILE%"

:: ===============================
:: Dump data only (specific tables)
:: ===============================
sqlite3 "%DB_FILE%" ^
".dump error_message_groups ^
        error_messages ^
        checklist_types ^
        event_frequencies ^
        event_action_types ^
        label_types ^
        color_names ^
        search_item_types ^
        comment_types" ^
> "%DATA_FILE%"

:: ===============================
:: Merge schema + data
:: ===============================
cd "C:\xampp\htdocs\files\tabulasync\sql\ddl"
type "%SCHEMA_FILE%" "%DATA_FILE%" > "dump.sql"

:: ===============================
:: Cleanup
:: ===============================
del "%SCHEMA_FILE%" /Q
del "%DATA_FILE%" /Q

pause
```

