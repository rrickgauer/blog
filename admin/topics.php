<?php
// redirect to login page if I didnt log in
session_start();
if (!isset($_SESSION['loggedIn'])) {
  header('Location: login.php');
  exit;
}

include_once('functions.php');

//////////////////////////////////////////////////////////
// Display an alert if a topic was successfully created //
//////////////////////////////////////////////////////////
function topicInserted() {
  if (isset($_SESSION['topic-created']) && $_SESSION['topic-created'] == true) {
    echo getAlert('Topic was successfully created');
    unset($_SESSION['topic-created']);
  }
}

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
    <?php topicInserted(); ?>
    <h1 class="text-center mt-5 mb-5 custom-font">Topics</h1>

    <div class="toolbar toolbar-topics">

      <!-- search box -->
      <div class="left">
        <div>
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text"><i class="bx bx-search"></i></span>
            </div>
            <input type="text" class="form-control tablesearch-input" placeholder="Search..." data-tablesearch-table="#table-topics" autofocus>
          </div>
        </div>

        <div class="form-check form-check-inline">
          <input class="form-check-input" type="checkbox" id="toggle-unused-topics" value="yes">
          <label class="form-check-label" for="toggle-unused-topics">Show unused topics</label>
        </div>
      </div>

      <!-- new entry button -->
      <div class="right">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal-topic-new">New topic</button>
      </div>
    </div>

    <!-- topics table -->
    <div class="card">
      <div class="card-body">
        <div class="table-respsonsive">
          <table class="table table-sm tablesort tablesearch-table" id="table-topics">
            <thead>
              <tr>
                <th data-tablesort-type="int">ID</th>
                <th data-tablesort-type="string">Name</th>
                <th data-tablesort-type="int">Count</th>
                <th>Delete</th>
              </tr>
            </thead>
            <tbody></tbody>
          </table>
        </div>
      </div>
    </div>
  </div>

  <!-- new topic modal -->
  <div class="modal fade" id="modal-topic-new" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">New topic</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          
          <form>
            <!-- name -->
            <div class="form-group">
              <label for="new-topic">Name:</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text"><i class='bx bx-font'></i></span>
                </div>
                <input type="text" class="form-control" id="new-topic" name="new-topic" required>
                <div id="new-topic-invalid" class="invalid-feedback">
                  Topic name already exists
                </div>
              </div>
            </div>

            <!-- submit button -->
            <button type="button" class="btn btn-sm btn-primary btn-new-topic">Create new topic</button>
          </form>
        </div>
      </div>
    </div>
  </div>


  <?php include('footer.php'); ?>
  <script src="js/topics-js.js"></script>

</body>
</html>