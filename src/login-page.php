<?php
include('functions.php');

// check if user attempted to login
if (isset($_POST['username']) && isset($_POST['password'])) {

  // successful login
  if (isLoginSuccessful($_POST['username'], $_POST['password'])) {

    session_start();
    $_SESSION['loggedIn'] = true;
    header('Location: entries.php');
    exit;
  }
}

?>

<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>
  <title>Login</title>
</head>

<body>
  <?php include('navbar.php'); ?>

  <div class="container" id="content">
    <h1>Login</h1>


    <form class="form" method="post">
      <input type="text" name="username" class="form-control" placeholder="Username" autofocus required><br>
      <input type="password" name="password" class="form-control" placeholder="Password" required><br>
      <input type="submit" value="Log in" class="btn btn-primary ">

    </form>
  </div>

  <?php printFooter(); ?>



  <script>
    $("#login-nav").addClass("selected");
  </script>



</body>

</html>
