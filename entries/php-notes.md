## Content

1. [Background](#background)
2. [Connecting to Database](#connecting-to-database)
3. [Prepared SQL Statements](#prepared-sql-statements)
4. [Encoding JSON](#encoding-json)


## Background
This is going to be a working collection of notes I have on PHP. They will include code snippets that I frequently include in my projects, and other things of that nature.

## Connecting to Database

These 2 code snippets are how I usually connect to my database in php. Most of the time, I create a file called ```functions.php``` where I place the ```dbConnect()``` function. Then, on all my other files I use an ```include('functions.php');``` statement at the top.

### dbConnect()
```php
function dbConnect() {
  include('db-info.php');

  try {
    // connect to database
    $pdo = new PDO("mysql:host=$host;dbname=$dbName",$user,$password);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    return $pdo;

  } catch(PDOexception $e) {
      return 0;
  }
}
```

### db-info.php

```php
$user = "username";
$password = "password";
$dbName = "dbname";
$host = "localhost";
```

## Prepared SQL Statements

Prepared statements are a way of executing sql statements in a safe and efficient manner. They help protect against sql injection attacks, by sanitizing and filtering the data that is to be used in the statements. Using prepared statements over inserting raw query parameters into a SQL query is widely considered to be the proper approach when interacting with databases.

### Prepared statement readings

* [PHP Manual](https://www.php.net/manual/en/pdo.prepared-statements.php)
* [PHP: The Right Way](https://phptherightway.com/#pdo_extension)

### How I write prepared statements

Below are the steps I take when writing a prepared statement. This is not the only way to write correct prepared statements, and there are ways that I can improve them. However, these can help get anyone started. The steps I take are as followed:

1. Initialize the pdo object
2. Prepare the SQL statement
3. Filter the variables
4. Bind the parameters
5. Execute the sql statement and close the connections

### Initialize the pdo object

```php
$pdo = dbConnect();
```

### Prepare the SQL statement

```php
$sql = $pdo->prepare('SELECT id, dept, number FROM Classes where term=:term ORDER BY dept, number');
$sql = $pdo->prepare('UPDATE ListItems SET completed=:completed WHERE id=:id');
$sql = $pdo->prepare('INSERT INTO Lists (title) VALUES (:name)');
$sql = $pdo->prepare('DELETE FROM ListItems WHERE id=:id');
```

Notice the semicolin before the variable name!

### Filter the variables

You need to choose one of these next 2 options. The first option is for when you have a standard variable. The second option is when you want to use a global variable like ```$_POST``` or ```$_GET```.

#### Standard Variable
```php
$id = filter_var($id, FILTER_SANITIZE_NUMBER_INT);
```

#### Global Variable
```php
$listID = filter_input(INPUT_GET, 'listID', FILTER_SANITIZE_NUMBER_INT);            // get
$name = filter_input(INPUT_POST, 'update-todo-list-title', FILTER_SANITIZE_STRING); // post
```

For both functions, the last parameter is dependent on the type of variable (int, string, double, etc...) being passed in. The table below shows the corresponding relationships. [Source](https://www.php.net/manual/en/filter.filters.sanitize.php).

<table>
<tr><th>string</th> <td>FILTER_SANITIZE_STRING</td></tr>
<tr><th>int</th> <td> FILTER_SANITIZE_NUMBER_INT </td></tr>
<tr><th>double/float</th> <td>FILTER_SANITIZE_NUMBER_FLOAT</td></tr>
<tr><th>URL</th> <td>FILTER_SANITIZE_URL</td></tr>
<tr><th>email</th> <td>FILTER_SANITIZE_EMAIL</td></tr>
<tr><th>magic quotes</th><td> FILTER_SANITIZE_MAGIC_QUOTES</td></tr>
</table>


### Bind the parameter

```php
$sql->bindParam(':id', $id, PDO::PARAM_INT);
```

For the third parameter in bindParam(), depending on the variable type there are different options to choose from. Below is a table showing the different variable types and their respective predefined constant. Additional constants can be found [here](https://www.php.net/manual/en/pdo.constants.php).

<table>
<tr><th>string</th><td>PDO::PARAM_STR</td></tr>
<tr><th>int</th><td>PDO::PARAM_INT</td></tr>
<tr><th>double*</th><td>PDO::PARAM_STR</td></tr>
<tr><th>email, date, other</th><td>PDO::PARAM_STR</td></tr>
</table>

There are no predefined constants for a type double so it is [recommended](https://stackoverflow.com/a/2718737) to use the string constant.

### Execute the sql statement and close the connections

The final step is to execute the SQL statement and close the pdo object connections. It is good practice to explicitly close the pdo connections by setting the objects to null. If you don't do this, php will automatically close the connections when the script ends.

```php
// execute sql statement
$sql->execute();

// close the pdo connections
$pdo = null;
$sql = null;
```

### Example of a prepared statement

Below is an example of a php function that executes a simple prepared update statement to a MySQL database table using the steps I have listed above.

```php
// sets a todo list item as complete
function updateTodoListItemComplete($id, $completed) {
   $pdo = dbConnect();
   $sql = $pdo->prepare('UPDATE ListItems SET completed=:completed WHERE id=:id');

   // filter variables
   $id = filter_var($id, FILTER_SANITIZE_NUMBER_INT);
   $completed = filter_var($completed, FILTER_SANITIZE_STRING);

   // bind the parameters
   $sql->bindParam(':id', $id, PDO::PARAM_INT);
   $sql->bindParam(':completed', $completed, PDO::PARAM_STR);

   // execute sql statement
   $sql->execute();

   // close the pdo connections
   $pdo = null;
   $sql = null;
}
```

## Encoding JSON

If my file is used to handle ajax requests, then the file either returns raw html or data encoded in a json format. Here is I typically return data in a json format.

```php
$studentID = $_GET['studentID'];                                  // get the student id from GET
$student = getStudentInfo($studentID)->fetch(PDO::FETCH_ASSOC);   // call a function to return student data by id
$response = json_encode($student);                                // encode the student data in a json format
echo $response;                                                   // return the json data
```
