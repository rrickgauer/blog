<?php

// need to add a page does not exist here!!
if (!isset($_GET['id'])) {
	header('Location: entries.php');
}

include_once('functions.php');

deleteEntry($_GET['id']);

header('Location: edit-entry.php');
exit;

?>
