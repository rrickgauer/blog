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
  <div class=\"alert alert-$alertType alert-dismissible mt-3 fade show\" role=\"alert\">
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
  SELECT Entries.id,
         Entries.date,
         Entries.title,
         Entries.link,
         DATE_FORMAT(Entries.date, "%c/%d/%Y") AS date_display,
         Entries.topic_id,
         Topics.NAME                           AS topic_name
  FROM   Entries
         LEFT JOIN Topics
                ON Entries.topic_id = Topics.id
  GROUP  BY Entries.id
  ORDER  BY Entries.date DESC';

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
// topic_id                          //
// topic_name                        //
///////////////////////////////////////
function getEntry($entryID) {
  $stmt = '
  SELECT Entries.id,
         Entries.date,
         Entries.title,
         Entries.link,
         DATE_FORMAT(Entries.date, "%c/%d/%Y") AS date_display,
         DATE_FORMAT(Entries.date, "%Y-%m-%d") AS date_raw,
         Entries.topic_id,
         Topics.NAME                           AS topic_name
  FROM   Entries
         LEFT JOIN Topics
                ON Entries.topic_id = Topics.id
  WHERE  Entries.id = :entryID
  GROUP  BY Entries.id
  ORDER  BY Entries.date DESC';

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
function updateEntry($entryID, $title, $link, $date, $topicID) {
  $stmt = '
  UPDATE Entries
  SET    title    = :title,
         link     = :link,
         date     = :date,
         topic_id = :topicID
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

  // filter and bind topic id
  $topicID = filter_var($topicID, FILTER_SANITIZE_NUMBER_INT);
  $sql->bindParam(':topicID', $topicID, PDO::PARAM_INT);


  $sql->execute();
  return $sql;

}

////////////////////////
// Insert a new entry //
////////////////////////
function insertEntry($title, $link, $date, $topicID) {
  $stmt = '
  INSERT INTO Entries (title, link, date, opic_id)
  VALUES (:title, :link, :date, :topicID)';

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

  // filter and bind topic id
  $topicID = filter_var($topicID, FILTER_SANITIZE_NUMBER_INT);
  $sql->bindParam(':topicID', $topicID, PDO::PARAM_INT);


  $sql->execute();
  return $sql;
}

///////////////////////////////////////////////////////////////////////
// Validates a login attempt by checking if email and password match //
///////////////////////////////////////////////////////////////////////
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


/////////////////////
// Delete an entry //
/////////////////////
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

//////////////////////////////////////////////
// Returns all the topics from the database //
//                                          //
// id                                       //
// name                                     //
//////////////////////////////////////////////
function getTopics() {
  $stmt = 'SELECT * FROM Topics ORDER BY Name';
  $sql = dbConnect()->prepare($stmt);
  $sql->execute();

  return $sql;
}

//////////////////////////////////////////////
// Returns the html for the topics dropdown //
//////////////////////////////////////////////
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

/////////////////////////////////////////////////////////////
// Checks if the topic name already exists in the database //
/////////////////////////////////////////////////////////////
function isTopicNameTaken($name) {
  $stmt = '
  SELECT Topics.id,
         Topics.name
  FROM   Topics
  WHERE  name = :name
  LIMIT  1';

  $sql = dbConnect()->prepare($stmt);

  // filter and bind name
  $name = filter_var($name, FILTER_SANITIZE_STRING);
  $sql->bindParam(':name', $name, PDO::PARAM_STR);

  $sql->execute();
  $result = $sql->fetchAll(PDO::FETCH_ASSOC);

  // return the result
  if (count($result) == 0)
    return false;
  else
    return true;
}

//////////////////////////////////////
// Insert a topic into the database //
//////////////////////////////////////
function insertTopic($name) {
  $stmt = 'INSERT into Topics (name) values (:name)';
  $sql = dbConnect()->prepare($stmt);

  // filter and bind name
  $name = filter_var($name, FILTER_SANITIZE_STRING);
  $sql->bindParam(':name', $name, PDO::PARAM_STR);

  $sql->execute();
  return $sql;
}

//////////////////////////////////////////////////////////////
// Returns list of all used distinct topics and their count 
//
// id
// name
// count
//////////////////////////////////////////////////////////////
function getUsedDistinctTopics() {
  $stmt = '
  SELECT t.id,
         t.name,
         COUNT(Entries.id) AS count
  FROM   Topics t,
         Entries
  WHERE  t.id = Entries.topic_id
  GROUP  BY t.id
  ORDER  BY NAME ASC';

  $sql = dbConnect()->prepare($stmt);
  $sql->execute();

  return $sql;
}

////////////////////////////////////////////////////
// Returns the stats for the top of the home page //
//                                                //
// count_entries                                  //
// favorite_topic                                 //
// count_weekly_posts                             //
////////////////////////////////////////////////////
function getStats() {
  $stmt = '
  SELECT (SELECT COUNT(id)
          FROM   Entries)                            AS count_entries,
         (SELECT name
          FROM   (SELECT t.name,
                         COUNT(Entries.id) AS count
                  FROM   Entries,
                         Topics t
                  WHERE  t.id = Entries.topic_id
                  GROUP  BY t.id
                  ORDER  BY count DESC
                  LIMIT  1) AS t)                    AS favorite_topic,
         (SELECT COUNT(e.id)
          FROM   Entries e
          WHERE  YEARWEEK(e.date) = YEARWEEK(NOW())) AS count_weekly_posts';


  $sql = dbConnect()->prepare($stmt);
  $sql->execute();
  return $sql;
}


?>