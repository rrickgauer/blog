<?php include('functions.php'); ?>
<?php include('Parsedown.php'); ?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>

  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css">

  <link href="https://fonts.googleapis.com/css?family=Special+Elite&display=swap" rel="stylesheet" />

  <title>Ryan Rickgauer Blog</title>
</head>

<body>



  <div class="wrapper">
    
    <div id="sidebar">

      <div class="sidebar-header">
        Entries
        <div class="float-right">
          <i class="bx bx-x toggle-entries" id="hide-entries"></i>
        </div>
      </div>

      <ul class="list-unstyled">

      <li><h3>2019</h3></li>
        <?php
          $entries = getAllEntries();
          while ($entry = $entries->fetch(PDO::FETCH_ASSOC)) {

            $id = $entry['id'];
            $title = $entry['title'];
            echo "<li><a class=\"sidebar-link\" href=\"entries.php?entryID=$id\">$title</a></li>";
          }
        ?>
      </ul>
    </div>



    <div id="data" class="container">

        <i class="bx bx-menu toggle-entries active" id="show-entries"></i>

        <?php

        if (isset($_GET['entryID'])) {
          $entry = getEntry($_GET['entryID']);

          echo '<h1 class="custom-font">' . $entry['title'] . '</h1>';
          echo '<h6 class="text-center entry-date">' . $entry['date'] . '</h6>';

          $Parsedown = new Parsedown();
          echo $Parsedown->text($entry['content']);

        } else {
          include('home.php');
        }

        ?>

        <div id="home-footer">
    <a href="https://github.com/rrickgauer/blog" target="_blank"><i class='bx bxl-github'></i></a>
  </div>

    </div>
  </div>

<script src="js/prism.js"></script>

<script>

  $(document).ready(function() {

    $(".toggle-entries").on("click", function() {
      $('#sidebar').toggleClass('active');
      $('#data').toggleClass('active');
      $('.toggle-entries').toggleClass('active');
    });

    $(".sidebar-link").on('click', function() {
      $(".sidebar-link").removeClass('active');
      $(this).addClass('active');
    });

  });



</script>


</body>

</html>
