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


    $url = '../entries/goals-for-2020.md';

    // using file() function to get content
    $lines_array=file($url);
    
    // turn array into one variable
    $lines_string=implode('',$lines_array);

    // output the file
    $Parsedown = new Parsedown();
    echo $Parsedown->text($lines_string);

    ?>



  </div>












</body>

</html>
