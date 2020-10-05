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


//////////////////////////////////////
// Returns a http response code 400 //
//////////////////////////////////////
function getBadResponseCode() {
  return http_response_code(400);
}

///////////////////////////////
// returns a bootstrap alert //
///////////////////////////////
function getAlert($message, $alertType = 'success') {
  return "
  <div class=\"alert alert-$alertType alert-dismissible fade show\" role=\"alert\">
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
// topic_id             //
// topic_name           //
//////////////////////////
function getEntries() {
  $stmt = '
  SELECT  Entries.id,
          Entries.date,
          Entries.title,
          Entries.link,
          DATE_FORMAT(Entries.date, "%c/%d/%Y") AS date_display,
          Entries.topic_id,
          Topics.name as topic_name
  FROM    Entries
  LEFT JOIN Topics on Entries.topic_id = Topics.id
  GROUP BY Entries.id
  ORDER BY Entries.date desc';

  $sql = dbConnect()->prepare($stmt);
  $sql->execute();
  return $sql;
}

///////////////////////////////////////
// Retrieves data for a single entry //
//                                   //
// id                                //
// title                             //
// date_display                      //
// date_raw                          //
// link                              //
///////////////////////////////////////
function getEntry($entryID) {
  $stmt = '
  SELECT e.id,
         e.title,
         DATE_FORMAT(e.date, "%c/%d/%Y") AS date_display,
         DATE_FORMAT(e.date, "%Y-%m-%d") as "date_raw",
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


//////////////////////
// Updates an entry //
//////////////////////
function updateEntry($entryID, $title, $link, $date) {
  $stmt = '
  UPDATE Entries
  SET    title = :title,
         link = :link,
         date = :date
  WHERE  id = :entryID';

  $sql = dbConnect()->prepare($stmt);


  // filter and bind id
  $entryID = filter_var($entryID, FILTER_SANITIZE_NUMBER_INT);
  $sql->bindParam(':entryID', $entryID, PDO::PARAM_INT);

  // filter and bind title
  $title = filter_var($title, FILTER_SANITIZE_STRING);
  $sql->bindParam(':title', $title, PDO::PARAM_STR);

  // filter and bind link
  $link = filter_var($link, FILTER_SANITIZE_URL);
  $sql->bindParam(':link', $link, PDO::PARAM_STR);

  // filter and bind date
  $date = filter_var($date, FILTER_SANITIZE_STRING);
  $sql->bindParam(':date', $date, PDO::PARAM_STR);


  $sql->execute();
  return $sql;

}

////////////////////////
// Insert a new entry //
////////////////////////
function insertEntry($title, $link, $date) {
  $stmt = '
  INSERT INTO Entries (
    title,
    link,
    date
  )
  
  VALUES (
    :title,
    :link,
    :date
  )';

  $sql = dbConnect()->prepare($stmt);

  // filter and bind title
  $title = filter_var($title, FILTER_SANITIZE_STRING);
  $sql->bindParam(':title', $title, PDO::PARAM_STR);

  // filter and bind link
  $link = filter_var($link, FILTER_SANITIZE_URL);
  $sql->bindParam(':link', $link, PDO::PARAM_STR);

  // filter and bind date
  $date = filter_var($date, FILTER_SANITIZE_STRING);
  $sql->bindParam(':date', $date, PDO::PARAM_STR);


  $sql->execute();
  return $sql;
}


function isValidEmailAndPassword($email, $password) {
  $stmt = '
  SELECT password
  FROM   Users
  WHERE  email = :email
  LIMIT  1';

  $sql = dbConnect()->prepare($stmt);

  // filter and bind email
  $email = filter_var($email, FILTER_SANITIZE_EMAIL);
  $sql->bindParam(':email', $email, PDO::PARAM_STR);

  // fetch results
  $sql->execute();
  $result = $sql->fetch(PDO::FETCH_ASSOC);

  // return if there is a match
  if ($result['password'] == $password)
    return true;
  else
    return false;
}


// Delete an entry
function deleteEntry($entryID) {
  $stmt = '
  DELETE FROM Entries
  WHERE  id = :entryID';

  $sql = dbConnect()->prepare($stmt);

  // filter and bind id
  $entryID = filter_var($entryID, FILTER_SANITIZE_NUMBER_INT);
  $sql->bindParam(':entryID', $entryID, PDO::PARAM_INT);

  $sql->execute();
  return $sql;
}


function getTopics() {
  $stmt = 'SELECT * FROM Topics ORDER BY Name';
  $sql = dbConnect()->prepare($stmt);
  $sql->execute();

  return $sql;
}

function getNewEntryTopicsSelectHtml() {
  $topics = getTopics();

  $html = '';
  while ($topic = $topics->fetch(PDO::FETCH_ASSOC)) {
    $id   = $topic['id'];
    $name = $topic['name'];

    if ($name == 'None')
      $html .= "<option value=\"$id\" selected>$name</option>";
    else
      $html .= "<option value=\"$id\">$name</option>";
  }

  return $html;
}


















?>