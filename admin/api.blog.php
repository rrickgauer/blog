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










?>