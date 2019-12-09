<?php
include_once('functions.php');

$entry = getEntry($_GET['id']);

?>

<!DOCTYPE html>
<html lang="en" dir="ltr">
   <head>
      <?php include('header.php'); ?>
      <title></title>
   </head>
   <body>
      <div class="container-fluid">

         <h1><?php echo $entry['title']; ?></h1>

         <div id="content">
            <?php echo $entry['content']; ?>

         </div>







      </div>
   </body>
</html>
