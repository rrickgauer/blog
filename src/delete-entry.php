<?php
include_once('include-top.php');

// need to add a page does not exist here!!
if (!isset($_GET['id'])) {
	header('Location: entries.php');
}

deleteEntry($_GET['id']);

header('Location: edit-entry.php');
exit;

?>
