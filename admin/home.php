<?php

// redirect to login page if I didnt log in
session_start();
if (!isset($_SESSION['loggedIn'])) {
  header('Location: login.php');
  exit;
}

include('functions.php'); 

/////////////////////////////////////////////////////
// display alert if entry was successfully created //
/////////////////////////////////////////////////////
function entryInserted() {
  if (isset($_SESSION['entry-inserted']) && $_SESSION['entry-inserted'] == 'true')
    echo getAlert('Entry was successfully created.');
    unset($_SESSION['entry-inserted']);
}

$stats = getStats()->fetch(PDO::FETCH_ASSOC);

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
    
    <h1 class="text-center mt-5 mb-5 custom-font">Entries Admin Page</h1>

    <div id="stats" class="card">
      <div class="card-header">
        <h3 class="custom-font">Your stats</h3>
      </div>

      <div class="card-body">

        <div class="stats-cards">
          <!-- number of entries -->
          <div class="card card-stat">
            <div class="card-body">
              <div class="card-icon">
                <i class='bx bx-note'></i>
              </div>
              <div class="card-data">
                <div class="card-description custom-font">
                  Entries
                </div>
                <div class="card-number">
                   <?php echo $stats['count_entries']; ?>
                </div>
              </div>            
            </div>
          </div>

          <!-- number of posts this week -->
          <div class="card card-stat">
            <div class="card-body">
              <div class="card-icon">
                <i class='bx bx-calendar-check'></i>
              </div>
              <div class="card-data">
                <div class="card-description custom-font">
                  Posts this week
                </div>
                <div class="card-number">
                   <?php echo $stats['count_weekly_posts']; ?>
                </div>
              </div>            
            </div>
          </div>

          <!-- favorite topic -->
          <div class="card card-stat">
            <div class="card-body">
              <div class="card-icon">
                <i class='bx bx-font'></i>
              </div>
              <div class="card-data">
                <div class="card-description custom-font">
                  Most used topic
                </div>
                <div class="card-number">
                   <?php echo $stats['favorite_topic']; ?>
                </div>
              </div>            
            </div>
          </div>
          
        </div>

        <div class="stats-graphs">
          <canvas id="chart-topics" class="chart"></canvas>
          <canvas id="chart-entries" class="chart"></canvas>
        </div>

        
      </div>
    </div>

    <!-- entries table -->
    <div class="card mb-5">
      <div class="card-header">
        <h3 class="custom-font">Entries</h3>
      </div>
      <div class="card-body">

        <div class="toolbar toolbar-table">
          <!-- search box -->
          <div class="left">
            <!-- search box -->
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text"><i class="bx bx-search"></i></span>
              </div>
              <input type="text" class="form-control tablesearch-input" placeholder="Search..." data-tablesearch-table="#table-entries" autofocus>
            </div>

            <!-- filter by tag -->
            <select class="form-control" id="filter-topics">
              <option value="SHOW_ALL" selected>All</option>
            </select>
          </div>

          <!-- new entry button -->
          <div class="right">
            <!-- <button type="button" class="btn btn-sm btn-secondary" data-toggle="modal" data-target="#modal-topic-new">New topic</button> -->
            <button type="button" class="btn btn-sm btn-secondary" data-toggle="modal" data-target="#modal-entry-new">New entry</button>
          </div>
        </div>
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
                <label for="edit-entry-link">Link:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-link"></i></span>
                  </div>
                  <input type="url" class="form-control" id="edit-entry-link" name="edit-entry-link">
                </div>
              </div>

              <!-- Date -->
              <div class="form-group">
                <label for="edit-entry-date">Date:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-calendar"></i></span>
                  </div>
                  <input type="date" class="form-control" id="edit-entry-date" name="edit-entry-date">
                </div>
              </div>

              <!-- Topic -->
              <div class="form-group">
                <label for="edit-entry-topic">Topic:</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="bx bx-calendar"></i></span>
                  </div>
                  <select class="form-control" id="edit-entry-topic" name="edit-entry-topic" required>
                    <?php echo getNewEntryTopicsSelectHtml(); ?>
                  </select>
                </div>
              </div>

              <button type="button" class="btn btn-sm btn-primary btn-submit-entry-edit">Save</button>
            </form>
          </div>

          <div class="modal-footer">
            <a href="#" target="_blank" class="btn btn-sm btn-secondary btn-link-post">Check post</a>
            <a href="#" target="_blank" class="btn btn-sm btn-secondary btn-link-source">View source</a>
            <button type="button" class="btn btn-sm btn-danger btn-delete-entry">Delete</button>
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

              <input type="submit" value="Create entry" class="btn btn-sm btn-primary">
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