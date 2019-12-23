<?php include_once('include-top.php'); ?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>

  <!-- include Select2 -->
  <link href="https://cdn.jsdelivr.net/npm/select2@4.0.12/dist/css/select2.min.css" rel="stylesheet" />
  <script src="https://cdn.jsdelivr.net/npm/select2@4.0.12/dist/js/select2.min.js"></script>

  <!-- select2 bootstrap css -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2-bootstrap-theme/0.1.0-beta.10/select2-bootstrap.css" />

  <title>Edit entry</title>
</head>

<body>
  <?php include('navbar.php'); ?>
  <div class="container">
    <h1>Edit entry</h1>

    <!-- select entry dropdown -->
    <select class="form-control form-control-lg col-sm-12" name="state" id="select-entry">
      <option>Select entry</option>
      <?php printTitleSelectOptions(); ?>
    </select><br>

    <?php
    if (isset($_GET['id'])) {
      $entry = getEntry($_GET['id']);
    }
    ?>

    <!-- edit entry form section -->
    <div class="<?php if (!isset($entry)) echo  'd-none'?>">
      <form class="form" method="post" action="update-entry.php?id=<?php if (isset($entry)) echo $entry['id']; ?>">

        <!-- title -->
        <div class="form-group">
          <label for="title" class="font-weight-bold">Title:</label>
          <input type="text" class="form-control" id="title" name="title" value="<?php if (isset($entry)) echo $entry['title']; ?>">
        </div>

        <!-- content -->
        <div class="form-group">
          <label for="content" class="font-weight-bold">Content:</label>
          <textarea class="form-control widgEditor" rows="20" id="content" name="content"><?php if (isset($entry)) echo $entry['content']; ?></textarea>
        </div>

        <!-- save -->
        <div class="float-right">
          <button type="button" class="btn btn-secondary" onclick="deleteEntry()">Delete</button>
          <input type="submit" value="Save" class="btn btn-primary">
        </div>
      </form>

    </div>

    <!-- expand and preview button group -->
    <div class="btn-group" role="group" aria-label="Basic example">
      <!-- expand textarea button -->
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#fullscreen-modal" id="fullscreen-button" onclick="enableFullScreen()" data-backdrop="static" data-keyboard="false">Expand</button>
      <!-- preview entry button -->
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#preview-modal" id="preview-button" onclick="setPreviewContent()">Preview</button>
    </div>
  </div>



  <!-- preview content modal -->
  <div class="modal" id="preview-modal">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h3 class="modal-title">Preview</h3>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body" id="preview-section"></div>
      </div>
    </div>
  </div>

  <!-- full screen editor modal -->
  <div class="modal" id="fullscreen-modal">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">

          <!-- preview entry button -->
          <button type="button" class="btn btn-primary" onclick="setPreviewFromExpand()">Preview</button>

          <!-- close modal -->
          <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="setSmallerTextareaContent()">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <textarea id="fullscreen-edit-section"></textarea>
        </div>
      </div>
    </div>
  </div>

  <!-- adds padding to the bottom of the page for looks -->
  <div class="padding-bottom"></div>

  <script>
    $(document).ready(function() {

      $('select').on('change', function() {
        var id = this.value;
        window.location.href = 'edit-entry.php?id=' + id;
      });

      // set select-entry to select2 plugin
      $("#select-entry").select2({theme: "bootstrap"});

      // sets the navbar item to selected
      $("#edit-entry-nav").addClass("selected");
    });

    function setPreviewContent() {
      var content = document.getElementById("content").value;
      document.getElementById("preview-section").innerHTML = content;
    }

    function enableFullScreen() {
      var content = document.getElementById("content").value;
      document.getElementById("fullscreen-edit-section").value = content;
    }

    function setSmallerTextareaContent() {

      var content = document.getElementById("fullscreen-edit-section").value;
      document.getElementById("content").value = content;
    }

    function setPreviewFromExpand() {
      setSmallerTextareaContent();
      setPreviewContent();
      $('#fullscreen-modal').modal('hide');
      $('#preview-modal').modal('show');
    }


    // function deleteEntry() {
    //  if (confirm('Are you sure you want to delete this post?')) {
    //    window.location.href = 'delete-entry.php?id=<?php //if (isset($entry)) echo $_GET['id']; ?>';
    //  }
    // }
  </script>

</body>

</html>
