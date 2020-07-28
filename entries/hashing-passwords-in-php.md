Hashing a password in php is pretty straightforward. The a built in functions ```password_hash()``` and ```password_verify()``` do most of the work for you. For a more in depth tutorial, check out the official docs for [password hash](https://www.php.net/manual/en/function.password-hash.php) and [password verify](https://www.php.net/manual/en/function.password-verify.php).

## Password Hash

```password_hash()``` returns a new password hash using a strong one-way hashing algorithm. To call ```password_hash()```, use it like this:

```php
$hashedPassword = password_hash($password, PASSWORD_DEFAULT);
```

*Note:* the hashed password can be up to 255 characters long, so you need to be sure to make the length of the password field in your database at least 255 characters long.

## Password Verify

```password_verify()``` verifies that the given hash matches the given password. To call ```password_verify()```, use it like this:

```php
$result = password_verify($password, $hashedPassword);
```

The result is a bool (true or false) that tells if the first argument matches the second argument (the hashed password).

## Example

Say we have a web application that stores usernames and passwords. 

To insert a new username and password combination using pdo, we could do something like this:

```php
// insert a new username record into the database
function insertNewUsername($username, $password) {
  $pdo = dbConnect();
  $sql = $pdo->prepare('INSERT INTO Users (username, password) VALUES (:username, :password)');

  // sanitize and bind username
  $username = filter_var($username, FILTER_SANITIZE_STRING);
  $sql->bindParam(':username', $username, PDO::PARAM_STR);

  // sanitize, hash, and bind password
  $password = filter_var($password, FILTER_SANITIZE_STRING);
  $hashedPassword = password_hash($password, PASSWORD_DEFAULT);
  $sql->bindParam(':password', $hashedPassword, PDO::PARAM_STR);

  $sql->execute();

  return $sql;
}
```

Now, let's say a user wanted to login to their account by entering in their username and password. We could validate the login attempt like this:

```php
function isValidUsernameAndPassword($username, $password) {
  $pdo = dbConnect();
  $sql = $pdo->prepare('SELECT password FROM Users WHERE username=:username LIMIT 1');

  // sanitize and bind username
  $username = filter_var($username, FILTER_SANITIZE_STRING);
  $sql->bindParam(':username', $username, PDO::PARAM_STR);

  $sql->execute();

  // username does not exist
  if ($sql->rowCount() != 1) {
    return false;
  }

  // username exists, now check if the passwords match
  else {
    $hash = $sql->fetch(PDO::FETCH_ASSOC);
    $hash = $hash['password'];

    return password_verify($password, $hash);
  }
}
```

If the function returns true, then the passwords match and the login attempt is valid.