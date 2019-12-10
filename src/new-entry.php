<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
	<?php include('header.php'); ?>

	<!-- NiceEdit -->
	<!-- <script src="http://js.nicedit.com/nicEdit-latest.js" type="text/javascript"></script>
   <script type="text/javascript">bkLib.onDomLoaded(nicEditors.allTextAreas);</script> -->

	<!-- include summernote css/js -->
	<!-- 	<link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.css" rel="stylesheet" />
	<script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.js"></script>
 -->

	<!-- widearea textarea plugin -->
	<link rel="stylesheet" type="text/css" href="widearea.css">
	<script type="text/javascript" src="widearea.js"></script>


	<title>New blog entry</title>
</head>

<body>
	<?php include('navbar.php'); ?>

	<div class="container">

		<h1>New Entry</h1>

		<form class="form" method="post" action="insert-entry.php">

			<!-- title -->
			<div class="form-group">
				<label for="title" class="font-weight-bold">Title:</label>
				<input type="text" class="form-control" id="title" name="title">
			</div>

			<!-- content -->
			<div class="form-group">
				<label for="content" class="font-weight-bold">Content:</label>
				<textarea id="content" name="content" data-widearea="enable" class="form-control" rows="20"></textarea>
			</div>

			<input type="submit" value="Submit" class="btn btn-primary">

		</form>
	</div>





	<script>
		$(document).ready(function() {
			$("#new-entry-nav").addClass("selected");
		});
	</script>


	<script>
		wideArea();
	</script>





</body>

</html>
