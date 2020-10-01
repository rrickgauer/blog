<?php

// return a pdo database object
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

// returns a bootstrap alert
function getAlert($message, $alertType = 'success') {
  return "
  <div class=\"alert alert-$alertType alert-dismissible mt-5 mb-5 fade show\" role=\"alert\">
    $message
    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">
      <span aria-hidden=\"true\">&times;</span>
    </button>
  </div>";
}
?>