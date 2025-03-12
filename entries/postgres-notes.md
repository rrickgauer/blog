
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

## Further Reading

* https://wiki.postgresql.org/wiki/Don't_Do_This