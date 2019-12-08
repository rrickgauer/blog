<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>

	<?php include('header.php'); ?>

	<title>New blog entry</title>
</head>

<body>

	<div class="container">

		<h1>New Entry</h1>

		<form class="form" method="post" action="entry.php">


			<div class="form-group">
				<label for="title" class="font-weight-bold">Title:</label>
				<input type="text" class="form-control" id="title" name="title">
			</div>

			<div class="form-group">
				<label for="content" class="font-weight-bold">Content:</label>
				<textarea  class="form-control widgEditor" rows="20" id="content" name="content"></textarea>
			</div>

         <input type="submit" value="Submit" class="btn btn-primary">




		</form>






	</div>
</body>

</html>
