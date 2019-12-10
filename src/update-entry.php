<?php

include_once('functions.php');
$id = $_GET['id'];

updateEntry($_GET['id'], $_POST['title'], $_POST['content']);

header('Location: entry.php?id=' . $id);
exit;

?>
