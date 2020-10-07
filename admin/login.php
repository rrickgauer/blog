<?php

include('functions.php');

// display error if invalid login
function invalidLogin() {
  if (isset($_GET['logged-in']))
    echo getAlert('Email and password do not match.', 'danger');
}

// check the remember email checkbox if it was saved already
function markCheckbox() {
  if (isset($_COOKIE['save-email'])) {
    echo 'checked';
  }
}

// set the email to saved email
function displaySavedEmail() {
  if (isset($_COOKIE['save-email'])) {
    echo ' value="' . $_COOKIE['save-email'] . '" ';
  }
}
?>

<!DOCTYPE html>
<html>
<head>
  <title>Log in</title>
  <?php include('header.php'); ?>
</head>
<body>

  <div class="container">
    <h1 class="text-center mt-huge mb-5">Admin Login</h1>

    <!-- login form -->
    <div class="card card-login">
      <div class="card-body">

        <?php invalidLogin(); ?>

        <form method="post" action="api.blog.php">
          <!-- email -->
          <div class="form-group">
            <label for="login-email">Email address</label>
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">@</span>
              </div>
              <input type="email" class="form-control" id="login-email" name="login-email" <?php displaySavedEmail(); ?> required>
            </div>
          </div>

          <!-- password -->
          <div class="form-group">
            <label for="login-password">Password</label>
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text"><i class="bx bx-lock-alt"></i></span>
              </div>
              <input type="password" class="form-control" id="login-password" name="login-password" required>
            </div>
          </div>

          <!-- remember my email checkbox -->
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="checkbox" name="login-save-email" id="login-save-email" value="true" <?php markCheckbox(); ?> >
            <label class="form-check-label" for="login-save-email">Remember my email</label>
          </div>

          <input type="submit" value="Log in" class="btn btn-primary float-right">
        </form>
      </div>
    </div>

  </div>


  <?php include('footer.php'); ?>

</body>
</html>