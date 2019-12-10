<?php
include_once('include-top.php');

if (isset($_POST['username']) && isset($_POST['password'])) {
	// check if login is correct
	if (isLoginSuccessful($_POST['username'], $_POST['password'])) {
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

	<div class="container">
		<h1>Login</h1>


		<form class="form" method="post">
			<input type="text" name="username" class="form-control" placeholder="Username" autofocus required><br>
			<input type="text" name="password" class="form-control" placeholder="Password" required><br>
			<div class="float-right">
				<input type="submit" value="Log in" class="btn btn-primary">
			</div>
		</form>





	</div>

	<script>
		$("#login-nav").addClass("selected");
	</script>

</body>

</html>
