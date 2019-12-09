<?php
// connects to DB
// returns the PDO connection
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

function insertEntry($title, $content) {

   $pdo = dbConnect();
   $sql = "INSERT INTO Entries (date, title, content) VALUES (CURRENT_TIMESTAMP(), \"$title\", \"$content\")";
   $result = $pdo->exec($sql);

   $sql = 'SELECT id FROM Entries ORDER BY id desc LIMIT 1';
   $result = $pdo->query($sql);
   $row = $result->fetch(PDO::FETCH_ASSOC);

   $pdo = null;

   return $row['id'];
}

function getEntry($id) {

   $pdo = dbConnect();
   $sql = "SELECT * FROM Entries WHERE id=$id";
   $result = $pdo->query($sql);

   return $result->fetch(PDO::FETCH_ASSOC);

}





?>
