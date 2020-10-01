<?php

include_once('functions.php');


////////////////////////////////////////////
// Retrieve all entries from the database //
////////////////////////////////////////////
if (isset($_GET['function']) && $_GET['function'] == 'get-entries') {
  $entries = getEntries()->fetchAll(PDO::FETCH_ASSOC);
  echo json_encode($entries);
  exit;
}

//////////////////////////////////////
// Retrieve data for a single entry //
//////////////////////////////////////
else if (isset($_GET['function'], $_GET['entryID']) && $_GET['function'] == 'get-entry') {
  $entryID = $_GET['entryID'];
  $entry = getEntry($entryID)->fetch(PDO::FETCH_ASSOC);
  echo json_encode($entry);
  exit;
}


else if (isset($_POST['function'], $_POST['entryID']) && $_POST['function'] == 'update-entry') {
  $entryID = $_POST['entryID'];
  $title   = $_POST['title'];
  $link    = $_POST['link'];
  $date    = $_POST['date'];

  $result = updateEntry($entryID, $title, $link, $date);

  // return error response if there was an error
  if ($result->rowCount() != 1) {
    echo getBadResponseCode();
  }

  exit;
}

////////////////////////
// Insert a new entry //
////////////////////////
else if (isset($_POST['new-entry-title'], $_POST['new-entry-link'], $_POST['new-entry-date'])) {
  $title = $_POST['new-entry-title'];
  $link  = $_POST['new-entry-link'];
  $date  = $_POST['new-entry-date'];

  $result = insertEntry($title, $link, $date);
  header('Location: home.php?entry-inserted=true');
  exit;

}







?>