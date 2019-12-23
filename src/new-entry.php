<?php include_once('include-top.php'); ?>

<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>

  <!-- widearea textarea plugin -->
  <link rel="stylesheet" type="text/css" href="css/widearea.css">
  <script type="text/javascript" src="js/widearea.js"></script>

  <title>New blog entry</title>
</head>

<body>
  <?php include('navbar.php'); ?>

  <div class="container">

    <h1>New Entry</h1>

    <form class="form" method="post" action="insert-entry.php">

      <!-- title -->
      <div class="form-group">
        <label for="title" class="font-weight-bold">Title:</label>
        <input type="text" class="form-control" id="title" name="title">
      </div>

      <!-- content -->
      <div class="form-group">
        <label for="content" class="font-weight-bold">Content:</label>
        <textarea id="content" name="content" data-widearea="enable" class="form-control" rows="20"></textarea>
      </div>

      <input type="submit" value="Submit" class="btn btn-primary">

    </form>
  </div>


  <script>
    $(document).ready(function() {
      $("#new-entry-nav").addClass("selected");
    });
  </script>


  <script>
    wideArea();
  </script>


</body>

</html>
