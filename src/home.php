<?php include('functions.php'); ?>
<?php include('Parsedown.php'); ?>
<?php $entries = getAllEntries(); ?>

<!DOCTYPE html>
<html>
<head>
  <?php include('header.php'); ?>
  <title>Ryan Rickgauer's Blog</title>
</head>
<body>

  <div class="container">

    <h1 id="hero" class="custom-font mt-5 mb-5">Ryan Rickgauer's Blog</h1>

    <ul class="list-group list-group-flush">
      <?php
        while ($entry = $entries->fetch(PDO::FETCH_ASSOC)) {
          $id = $entry['id'];
          $title = $entry['title'];
          $date = $entry['date_formatted'];

          echo '<li class="list-group-item entry">';
          echo "<div  class=\"title\"><a href=\"entries.php?entryID=$id\">$title</a></div>";
          echo "<div class=\"date\">$date</div>";
          echo '</li>';
        }
      ?>
    </ul>
  </div>

  
  <script>
    new TypeIt('.custom-font', {
      speed: 50,
      startDelay: 900
    })
    .options({speed: 50})
    .go();
  </script>

</body>
</html>