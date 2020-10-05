<?php

// redirect to login page if I didnt log in
session_start();
if (!isset($_SESSION['loggedIn'])) {
  header('Location: login.php');
  exit;
}

include('functions.php'); 

// display alert if entry was successfully created
function entryInserted() {
  if (isset($_GET['entry-inserted']) && $_GET['entry-inserted'] == 'true')
    echo getAlert('Entry was successfully created.');
}

?>
<!DOCTYPE html>
<html>
<head>
  <?php include('header.php'); ?>
  <title>Blog admin site</title>
</head>
<body>
  <?php include('navbar.php'); ?>

  <div class="container">

    <?php entryInserted(); ?>

    <h1 class="text-center mt-5 mb-5">Entries Admin Page</h1>

    <div class="table-toolbar">
      <!-- search box -->
      <div class="left">
        <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text"><i class="bx bx-search"></i></span>
          </div>
          <input type="text" class="form-control tablesearch-input" placeholder="Search..." data-tablesearch-table="#table-entries" autofocus>
        </div>
      </div>

      <!-- new entry button -->
      <div class="right">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal-entry-new">New entry</button>
      </div>
    </div>

    <!-- entries table -->
    <div class="table-responsive">
      <table class="table table-sm table-entries tablesort tablesearch-table" id="table-entries">
        <thead>
          <tr>
            <th data-tablesort-type="int">ID</th>
            <th data-tablesort-type="string">Title</th>
            <th data-tablesort-type="date">Date</th>
            <th data-tablesort-type="string">Topic</th>
          </tr>
        </thead>
        <tbody></tbody> 
      </table>
    </div>

  </div>

  <section class="section-modals">

    <!-- edit entry modal -->
    <div class="modal" id="modal-entry-edit" tabindex="-1">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Edit Entry</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            
            <form>

              <!-- Title -->
              <div class="form-group">
                <label for="edit-entry-title">Title:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-font"></i></span>
                  </div>
                  <input type="text" class="form-control" id="edit-entry-title" name="edit-entry-title">
                </div>
              </div>

              <!-- Link -->
              <div class="form-group">
                <label for="edit-entry-title">Link:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-link"></i></span>
                  </div>
                  <input type="url" class="form-control" id="edit-entry-link" name="edit-entry-link">
                </div>
              </div>

              <!-- Date -->
              <div class="form-group">
                <label for="edit-entry-title">Date:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-calendar"></i></span>
                  </div>
                  <input type="date" class="form-control" id="edit-entry-date" name="edit-entry-date">
                </div>
              </div>

              <button type="button" class="btn btn-primary btn-submit-entry-edit">Save</button>

              <button type="button" class="btn btn-danger btn-delete-entry">Delete</button>

            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- new entry modal -->
    <div class="modal fade" id="modal-entry-new" tabindex="-1">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">New Entry</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            
            <form method="post" action="api.blog.php">

              <!-- Title -->
              <div class="form-group">
                <label for="new-entry-title">Title:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-font"></i></span>
                  </div>
                  <input type="text" class="form-control" id="new-entry-title" name="new-entry-title" required>
                </div>
              </div>

              <!-- Link -->
              <div class="form-group">
                <label for="new-entry-link">Link:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-link"></i></span>
                  </div>
                  <select class="custom-select" id="select-entry-file">
                    <option value="" selected>Choose...</option>
                  </select>
                  <input type="url" class="form-control" id="new-entry-link" name="new-entry-link" required>
                </div>
              </div>

              <!-- Date -->
              <div class="form-group">
                <label for="new-entry-date">Date:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-calendar"></i></span>
                  </div>
                  <input type="date" class="form-control" id="new-entry-date" name="new-entry-date" required>
                </div>
              </div>

              <!-- Topic -->
              <div class="form-group">
                <label for="new-entry-topic">Topic:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-calendar"></i></span>
                  </div>
                  <select class="form-control" id="new-entry-topic" name="new-entry-topic" required>
                    <?php echo getNewEntryTopicsSelectHtml(); ?>
                  </select>
                </div>
              </div>

              <input type="submit" value="Create entry" class="btn btn-primary">
            </form>
          </div>
        </div>
      </div>
    </div>
    
  </section>

  <?php include('footer.php'); ?>
  <script src="js/home-js.js"></script>

</body>
</html>