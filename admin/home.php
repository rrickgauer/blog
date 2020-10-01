<?php include('functions.php'); ?>
<!DOCTYPE html>
<html>
<head>
  <?php include('header.php'); ?>
  <title>Blog admin site</title>
</head>
<body>
  <?php include('navbar.php'); ?>

  <div class="container">
    <h1 class="text-center mt-5 mb-5">Entries Admin Page</h1>


    <!-- entries table -->
    <div class="table-responsive">
      <table class="table table-sm table-entries">
        <thead>
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Date</th>
            <th>Link</th>
          </tr>
        </thead>
        <tbody></tbody> 
      </table>

    </div>

  </div>

  <?php include('footer.php'); ?>
  <script src="js/home-js.js"></script>

</body>
</html>