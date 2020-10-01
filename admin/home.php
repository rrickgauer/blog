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

  <section class="section-modals">

    <!-- entry modal -->
    <div class="modal fade" id="modal-entry-edit" tabindex="-1">
      <div class="modal-dialog">
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
                  <input type="text" class="form-control" id="edit-entry-date" name="edit-entry-date">
                </div>
              </div>

              <button type="button" class="btn btn-primary btn-submit-entry-edit">Save</button>

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