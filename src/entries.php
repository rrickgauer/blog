<?php
include('functions.php');
include('Parsedown.php');
$entry = getEntry($_GET['entryID']);
$Parsedown = new Parsedown();

?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>
  <title><?php echo $entry['title']; ?></title>
</head>

<body>
    <div id="data" class="container">
      <h1 class="custom-font post-title"><?php echo $entry['title']; ?></h1>
      <h6 class="text-center entry-date"><?php echo $entry['date']; ?></h6>
      <?php echo $Parsedown->text($entry['content']); ?>

      <div id="home-footer">
        <a href="https://github.com/rrickgauer/blog" target="_blank"><i class='bx bxl-github'></i></a>
      </div>
    </div>

  <script src="js/prism.js"></script>
  <script>
    new TypeIt('.custom-font', {
      speed: 50,
      startDelay: 900
    })
    .options({speed: 50})
    .go();
  </script>
</body>
</html>
