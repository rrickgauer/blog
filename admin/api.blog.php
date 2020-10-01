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








?>