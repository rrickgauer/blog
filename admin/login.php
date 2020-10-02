<?php include('functions.php'); ?>

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
        <form method="post" action="api.blog.php">

          <!-- email -->
          <div class="form-group">
            <label for="login-email">Email address</label>
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">@</span>
              </div>
              <input type="email" class="form-control" id="login-email" name="login-email" required>
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

          <input type="submit" value="Log in" class="btn btn-primary">
        </form>
      </div>
    </div>

  </div>


  <?php include('footer.php'); ?>

</body>
</html>