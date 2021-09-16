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
        echo $e->getMessage();  
        return 0;
    }
}

function insertEntry($title, $content) {

    $pdo = dbConnect();

    $content = addslashes($content);
    $title = addslashes($title);

    $sql = "INSERT INTO Entries (date, title, content) VALUES (CURRENT_DATE(), \"$title\", \"$content\")";
    $result = $pdo->exec($sql);

    $sql = 'SELECT id FROM Entries ORDER BY id desc LIMIT 1';
    $result = $pdo->query($sql);
    $row = $result->fetch(PDO::FETCH_ASSOC);

    $pdo = null;

    return $row['id'];
}

function updateEntry($id, $title, $content) {
    $pdo = dbConnect();

    $content = addslashes($content);
    $title = addslashes($title);

    $sql = "UPDATE Entries SET title=\"$title\", content=\"$content\" WHERE id=$id";
    $result = $pdo->exec($sql);

    $pdo = null;

}


/************************************************************
 * Returns the data for a single entry
 * 
 * id
 * title
 * link
 * date
**************************************************************/
function getEntry($id) {
    $stmt = '
    SELECT Entries.id,
            Entries.title,
            Entries.link,
            DATE_FORMAT(Entries.date, "%M %D, %Y") AS date
    FROM   Entries
    WHERE  id = :id
    LIMIT  1';

    $sql = dbConnect()->prepare($stmt);

    // filter and bind the parameters
    $id = filter_var($id, FILTER_SANITIZE_NUMBER_INT);
    $sql->bindParam(':id', $id, PDO::PARAM_INT);

    $sql->execute();
    return $sql;
}

function deleteEntry($id) {
    $pdo = dbConnect();
    $sql = "DELETE FROM Entries WHERE id=$id";
    $result = $pdo->exec($sql);
    $pdo = null;
    $result = null;
}

function printTitleSelectOptions() {

    $pdo = dbConnect();
    $sql = 'SELECT * from Entries ORDER BY Title desc';
    $result = $pdo->query($sql);

    while ($row = $result->fetch(PDO::FETCH_ASSOC)) {
        $id = $row['id'];
        $date = $row['date'];
        $title = $row['title'];
        $content = $row['content'];

        echo "<option value=\"$id\">$title</option>";
    }
}

function isLoginSuccessful($username, $password) {
    $pdo = dbConnect();
    $sql = $pdo->prepare('SELECT Authors.password FROM Authors WHERE Authors.username=:username');

    // filter variables
    $username = filter_var($username, FILTER_SANITIZE_STRING);

    // bind the parameters
    $sql->bindParam(':username', $username, PDO::PARAM_STR);

    // execute sql statement
    $sql->execute();

    // fetch the results
    $author = $sql->fetch(PDO::FETCH_ASSOC);

    // close the pdo connections
    $pdo = null;
    $sql = null;

    // return true if passwords match
    // otherwise, return false
    return ($password == $author['password']);
}

/**
 * Returns all entries
 * 
 * id
 * title
 * date
 * date_formatted
 * date_sort
 */
function getAllEntries() {
  $stmt = 'SELECT * FROM View_Entries ORDER BY date DESC, title';

  $sql = dbConnect()->prepare($stmt);
  $sql->execute();

  return $sql;
}

function printFooter() {
    echo "<div class=\"container-fluid\" id=\"footer\">
		<p>Made by <a href=\"https://www.ryanrickgauer.com/resume/index.html\">Ryan Rickgauer</a> &copy; 2019</p>
	</div>";
}


function getUsedTopics() {
    $stmt = 'CALL getUsedTopics()';
    $sql = dbConnect()->prepare($stmt);
    $result = $sql->execute();
    return $sql;
}




?>
