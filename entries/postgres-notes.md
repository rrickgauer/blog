
## Functions

Create a fuction that returns a text:

```sql
CREATE OR REPLACE FUNCTION build_username(first_name TEXT)
RETURNS TEXT
LANGUAGE 'plpgsql'
AS $BODY$
DECLARE prefix TEXT;
BEGIN
    prefix := 'user_' || first_name;
    return prefix;
END;
$BODY$;
```


Create a function that returns table:

```sql
CREATE OR REPLACE FUNCTION get_users(age INT)
RETURNS SETOF users 
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    RETURN query 
    SELECT u.*
    FROM users u
    where u.user_age = age;
END;
$BODY$;
```


## Procedures

```sql
CREATE OR REPLACE PROCEDURE normalize_checklist_item_positions(
    IN in_checklist_id INT
)
LANGUAGE 'plpgsql'
AS $BODY$
DECLARE public_id CHAR(24);
BEGIN
	public_id := get_checklist_public_id(in_checklist_id);
	CALL normalize_checklist_item_positions(public_id);
END
$BODY$;
```


## Domains

To create a `username` domain that must be greater than 20 characters: 

```sql
CREATE DOMAIN username 
CHECK (LENGTH(VALUE) > 20);
```

To create a domain with a regex constraint:

```sql
CREATE DOMAIN user_nanoid AS TEXT
CHECK (VALUE ~ '^clc_.{20}$');
```



## Identity Columns

```sql
CREATE TABLE table_name (
    id INTEGER NOT NULL UNIQUE GENERATED {ALWAYS | BY DEFAULT} AS IDENTITY PRIMARY KEY,
    column_name data_type,
    -- additional columns...
);
```


## UUID

To generate a new `UUID`:

```sql
SELECT gen_random_uuid();   -- 7A168FE6-E9A0-4B18-9CDC-FADFD50B9C49
```


## Row Types

https://www.postgresql.org/docs/current/plpgsql-declarations.html#PLPGSQL-DECLARATION-ROWTYPES


In procedures or functions, you can declare variables to be of a specific table `ROWTYPE`. 

For example, to access a single row in a procedure:

```sql
DECLARE event_row events%ROWTYPE;

SELECT * 
INTO event_row
FROM events
WHERE events.id = 3
LIMIT 1;

RAISE NOTICE 'selected event # %', event_row.id;
```


You can also use these types in a for loop:

```sql
DECLARE user_row users%ROWTYPE;

FOR user_row in 
    SELECT * FROM users
LOOP
    RAISE NOTICE 'current user id: %', user_row.id;
END LOOP;
```


## Adding Non-Unique Index

While UNIQUE ensures an index you might consider explicitly adding an index-only (non-unique) for faster queries:

```sql
CREATE INDEX idx_workspaces_public_id ON table_name(column_name);
```

## Timestamps

Don't use the `timestamp` type to store timestamps, use `timestamptz` (also known as timestamp with time zone) instead:

```sql
created_on timestamptz NOT NULL DEFAULT NOW();
```

https://wiki.postgresql.org/wiki/Don%27t_Do_This#Don.27t_use_timestamp_.28without_time_zone.29



## Further Reading

* https://wiki.postgresql.org/wiki/Don't_Do_This