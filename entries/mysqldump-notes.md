

## Table Schemas

This command dumps the database tables, views, procedures, functions, events, and triggers into a single file:

```sh
mysqldump -u {user_name} -h {ip_address} -p ^
--databases {DATABASE_NAME} ^
--no-create-db ^
--routines ^
--events ^
--triggers ^
--skip-quote-names ^
--no-data ^
--result-file "{output_file}"
```


## Reference Tables 

Most of my databases have reference tables, or predefined constants, that are used as foreign keys for other tables. 

For example, if I was making an application to store game data for each of the major sports leagues in the US, I would probably have a table in there called `Leagues` that has 4 rows representing the 4 major leagues: NFL, NBA, MLB, NHL. I usually end up mapping these tables to `Enums` in my source code.

```sh
mysqldump -u {user_name} -h {ip_address} -p ^
--no-create-db ^
--no-create-info ^
--replace ^
--order-by-primary ^
--skip-quote-names ^
--result-file "{output_file}" ^
{Database_Name} {Table_Name} {Table_Name} {Table_Name}
```


## Batch File

This is the standard format for a batch file that dumps the table schemas and reference tables into a single file:

```sh
mysqldump -u {user_name} -h {ip_address} -p ^
--databases Turma_Dev ^
--column-statistics=FALSE ^
--no-create-db ^
--routines ^
--events ^
--triggers ^
--skip-quote-names ^
--no-data ^
--result-file "C:\xampp\htdocs\files\turma\sql\ddl\.schemas.sql"


mysqldump -u {user_name} -h {ip_address} -p ^
--column-statistics=FALSE ^
--no-create-db ^
--no-create-info ^
--replace ^
--order-by-primary ^
--skip-quote-names ^
--result-file "C:\xampp\htdocs\files\turma\sql\ddl\.data.sql" ^
Turma_Dev Error_Message_Groups Error_Messages Server_Invitation_Status

@echo off
cd "C:\xampp\htdocs\files\turma\sql\ddl"

type ".schemas.sql" ".data.sql" > "dump.sql"

del ".schemas.sql" /Q
del ".data.sql" /Q

pause
```



