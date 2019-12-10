<?php
include_once('functions.php');
$entry = getEntry($_GET['id']);
?>

<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
	<?php include('header.php'); ?>

<link href="https://fonts.googleapis.com/css?family=Special+Elite&display=swap" rel="stylesheet" />

	<title><?php echo $entry['title'] ?></title>
</head>

<body>
	<?php include('navbar.php'); ?>
	<div class="container">

    <!-- entry title and date -->
    <div class="entry-title">
      <h1><?php echo $entry['title']; ?></h1>
      <h5><?php echo $entry['date']; ?></h5>
    </div>

    <br><br>
    <div id="content">
     <?php echo $entry['content']; ?>
   </div>

   <br><br>

 </div>

 <script src="js/prism.js"></script>


</body>

</html>
