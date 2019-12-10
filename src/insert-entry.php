<?php

include_once('include-top.php');
$id = insertEntry($_POST['title'], $_POST['content']);
header('Location: entry.php?id=' . $id);
exit;

?>
