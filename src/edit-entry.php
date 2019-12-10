<?php include('functions.php'); ?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
	<?php include('header.php'); ?>

	<!-- include Select2 -->
	<link href="https://cdn.jsdelivr.net/npm/select2@4.0.12/dist/css/select2.min.css" rel="stylesheet" />
	<script src="https://cdn.jsdelivr.net/npm/select2@4.0.12/dist/js/select2.min.js"></script>

	<!-- include summernote css/js -->
	<!-- <link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.css" rel="stylesheet" /> -->
	<!-- <script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.js"></script> -->

	<title>Edit entry</title>
</head>

<body>
	<?php include('navbar.php'); ?>

	<div class="container">

		<h1>Edit entry</h1>


		<select class="form-control col-sm-11" name="state" id="select-entry">
			<option>Select entry</option>
			<?php printTitleSelectOptions(); ?>
		</select>

		<br><br><br>

		<?php

		if (isset($_GET['id'])) {
			$entry = getEntry($_GET['id']);
		}


		?>



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

	</div>

	<script>
		$(document).ready(function() {

			$('select').on('change', function() {
				var id = this.value;
				window.location.href = 'edit-entry.php?id=' + id;
			});

			// set select-entry to select2 plugin
			$("#select-entry").select2();

			// set textarea plugin
			$('#content').summernote();

		});

		function deleteEntry() {
			if (confirm('Are you sure you want to delete this post?')) {
				window.location.href = 'delete-entry.php?id=<?php if (isset($entry)) echo $_GET['id']; ?>'
			}
		}



	</script>

</body>

</html>
