<?php

include('functions.php');

$pdo = dbConnect();
$sql = "select Entries.id, Entries.title, Entries.date, DATE_FORMAT(Entries.date, \"%M %D, %Y\") as 'date_formatted' from Entries ORDER BY date desc";
$results = $pdo->query($sql);




?>

<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
	<?php include('header.php'); ?>
	<title>Blog Entries</title>
</head>

<body>
	<div class="container">

		<h1>Browse</h1>

      <h2>2019</h2>

      <?php

      while ($entry = $results->fetch(PDO::FETCH_ASSOC)) {
         printEntryCard($entry['id'], $entry['title'], $entry['date_formatted']);
      }


      ?>













		</div>
</body>

</html>

<?php

function printEntryCard($id, $title, $date) {

   echo
   "<div class=\"card card-entry\">
      <div class=\"card-body\">
         <h5 class=\"card-title\"><a href=\"entry.php?id=$id\">$title</a></h5>
         <h6 class=\"card-subtitle mb-2 text-muted\">$date</h6>
      </div>
   </div>";
}


?>
