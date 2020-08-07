This is a short tutorial on how to connect to a MySQL database using python.

## Dependencies

In order to connect to your database, you first need to install the [MySQL Connector Python](https://github.com/mysql/mysql-connector-python) by entering in the terminal:

```
pip install mysql-connector-python
```

At the top of your script, you need to import the mysql module via:

```py
import mysql.connector
```

## Connecting to the database

To initialize the connection, you need to use ```mysql.connector.connect()```:

```py
# initialize database connection
mydb = mysql.connector.connect(
  host     = "host",
  user     = "user",
  passwd   = "password",
  database = "database"
)

# connect to database
mycursor = mydb.cursor()
```

## Select Statement

Here is an example case of a ```SELECT``` statement:

```py
# retrieve all user id's, first names, and last names
sql = "SELECT id, first_name, last_name from Users"
mycursor.execute(sql)
users = mycursor.fetchall()

# print the results
for user in users:
  print(user[0], user[1], user[2])  # id, first name, last name
```

### Using parameters

Using parameters in a statement is pretty straightforward. We are going to use the same example above, but only select the rows whose first name is 'Ryan' and last name is 'Smith':

```py
# retrieve all user id's, first names, and last names 
# whose first name is Ryan and last name is Smith
sql = "SELECT id, first_name, last_name FROM Users WHERE first_name = %s AND last_name = %s"
parm_first_name = "Ryan"
parm_last_name = "Smith"

# bind parameters into a tuple
parms = (parm_first_name, parm_last_name)

# execute the statement
mycursor.execute(sql, parms)
users = mycursor.fetchall()

# print the results
for user in users:
  print(user[0], user[1], user[2])  # id, first name, last name
```

## Insert Statement

Here is an example of an ```INSERT``` statement:

```py
sql = "INSERT INTO Users (first_name, last_name) VALUES (%s, %s)"

# set parms
first = "George"
last = "Washington"
parms = (first, last)

# execute insert statement
mycursor.execute(sql, val)
mydb.commit()

# print number of inserted records
print(mycursor.rowcount, "record updated.")
```
