<?php
include_once('functions.php');

$entry = getEntry($_GET['id']);

?>

<!DOCTYPE html>
<html lang="en" dir="ltr">
   <head>
      <?php include('header.php'); ?>
      <title><?php echo $entry['title'] ?></title>
   </head>
   <body>
      <?php include('navbar.php'); ?>
      <div class="container">

         <h1><?php echo $entry['title']; ?></h1>
         <h5><?php echo $entry['date']; ?></h5>

        <br><br>
         <div id="content">
            <?php echo $entry['content']; ?>
         </div>

      </div>
   </body>
</html>
