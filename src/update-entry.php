<?php
include_once('include-top.php');

$id = $_GET['id'];

updateEntry($_GET['id'], $_POST['title'], $_POST['content']);

header('Location: entry.php?id=' . $id);
exit;

?>
