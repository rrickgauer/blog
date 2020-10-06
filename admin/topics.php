<?php
// redirect to login page if I didnt log in
session_start();
if (!isset($_SESSION['loggedIn'])) {
  header('Location: login.php');
  exit;
}

include_once('functions.php');
?>

<!DOCTYPE html>
<html>
<head>
  <?php include('header.php'); ?>
  <title>Topics</title>
</head>
<body>
  <?php include('navbar.php'); ?>
  <div class="container">
    <h1 class="text-center mt-5 mb-5 custom-font">Topics</h1>

    <!-- table search input -->
    <div class="input-group mb-3">
      <div class="input-group-prepend">
        <span class="input-group-text"><i class="bx bx-search"></i></span>
      </div>
      <input type="text" class="form-control tablesearch-input" placeholder="Search..." data-tablesearch-table="#table-topics" autofocus>
    </div>

    <!-- topics table -->
    <div class="table-respsonsive">
      <table class="table table-sm tablesort tablesearch-table" id="table-topics">
        <thead>
          <tr>
            <th data-tablesort-type="int">ID</th>
            <th data-tablesort-type="string">Name</th>
            <th data-tablesort-type="int">Count</th>
          </tr>
        </thead>

        <tbody></tbody>
      </table>
    </div>
  </div>


  <?php include('footer.php'); ?>
  <script src="js/topics-js.js"></script>

</body>
</html>