<?php
include('include-top.php');
$entries = getAllEntries();
?>

<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>
  <title>Blog Entries</title>
</head>

<body>
  <?php include('navbar.php'); ?>


  <div class="container" id="content">

    <h1 class="text-center">Browse Entries</h1>

    <h2>2019</h2>
    <?php
    while ($entry = $entries->fetch(PDO::FETCH_ASSOC)) {
      printEntryCard($entry['id'], $entry['title'], $entry['date_formatted']);
    }
    ?>

  </div>

  <?php printFooter(); ?>

  <script>
    $(document).ready(function() {
      $("#entries-nav").addClass("selected");
    });
  </script>
</body>

</html>

<?php

function printEntryCard($id, $title, $date) {

   echo
   "<div class=\"card card-entry\">
   <div class=\"card-body\">
   <h3 class=\"card-title\"><a href=\"entry.php?id=$id\">$title</a></h3>
   <h6 class=\"card-subtitle mb-2 text-muted\">$date</h6>
   </div>
   </div>";
}


?>
