<?php include('functions.php'); ?>
<?php include('Parsedown.php'); ?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
	<?php include('header.php'); ?>
	<title></title>
</head>

<body>
	<div class="container">



		<?php 
		$Parsedown = new Parsedown();

		echo $Parsedown->text('# project name

## background
this is the backround

* one
* two
  * part 1
  * part 2');

			?>





		</div>












	</body>

	</html>
