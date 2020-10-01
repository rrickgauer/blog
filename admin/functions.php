<?php

//////////////////////////////////
// return a pdo database object //
//////////////////////////////////
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

///////////////////////////////
// returns a bootstrap alert //
///////////////////////////////
function getAlert($message, $alertType = 'success') {
  return "
  <div class=\"alert alert-$alertType alert-dismissible mt-5 mb-5 fade show\" role=\"alert\">
    $message
    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">
      <span aria-hidden=\"true\">&times;</span>
    </button>
  </div>";
}


//////////////////////////
// Retrieve all entries //
//                      //
// id                   //
// date                 //
// title                //
// link                 //
// date_display         //
//////////////////////////
function getEntries() {
  $stmt = '
  SELECT  e.id,
          e.date,
          e.title,
          e.link,
          DATE_FORMAT(e.date, "%c/%d/%Y") AS date_display
  FROM    Entries e
  ORDER BY e.title ASC';

  $sql = dbConnect()->prepare($stmt);
  $sql->execute();
  return $sql;
}

///////////////////////////////////////
// Retrieves data for a single entry //
//                                   //
// id                                //
// title                             //
// date                              //
// link                              //
///////////////////////////////////////
function getEntry($entryID) {
  $stmt = '
  SELECT e.id,
         e.title,
         DATE_FORMAT(e.date, "%Y-%m-%d") as "date",
         e.link
  FROM   Entries e
  WHERE  e.id = :entryID
  LIMIT  1';

  $sql = dbConnect()->prepare($stmt);

  // filter and bind entry id
  $entryID = filter_var($entryID, FILTER_SANITIZE_NUMBER_INT);
  $sql->bindParam(':entryID', $entryID, PDO::PARAM_INT);

  $sql->execute();
  return $sql;
}






















?>