<?php 
include('functions.php');
include('Parsedown.php');
include_once('HTML-Generator.php');

// fetch all the entries and generate their html
$entryListItemsHtml = '';
$entries = getAllEntries()->fetchAll(PDO::FETCH_ASSOC); 
for ($count = 0; $count < count($entries); $count++) {
    $entryListItemsHtml .= HTML::getHomeListItem($entries[$count]);
 }

// generate the html for the topics dropdown input element
$usedTopicsHtml = '';
$usedTopics = getUsedTopics()->fetchAll(PDO::FETCH_ASSOC);
for ($count = 0; $count < count($usedTopics); $count++) {
   $usedTopicsHtml .= HTML::getHomeTopicOption($usedTopics[$count]);
}

?>

<!DOCTYPE html>
<html>

<head>
    <?php include('header.php'); ?>
    <title>Ryan Rickgauer's Blog</title>
</head>

<body>
    <div class="container">
        <h1 id="hero" class="custom-font mt-5 mb-5">Ryan Rickgauer's Blog</h1>

        <div class="d-flex justify-content-between">
            <!-- filters -->
            <div class="toolbar-select toolbar-filter">
                <span class="label"><b>Filter:</b></span>
                <div>
                    <select class="form-control form-control-sm select-filter">
                        <option value="_all">All</option>
                        <?php echo $usedTopicsHtml; ?>
                    </select>
                </div>
            </div>

            <!-- sorting select options -->
            <div class="toolbar-select toolbar-sort">
                <span class="label"><b>Sort:</b></span>
                <div>
                    <select class="form-control form-control-sm select-sort">
                        <option value="date">Date</option>
                        <option value="title">Title</option>
                    </select>
                </div>
            </div>
        </div>

        <ul class="list-group list-group-flush">
            <?php echo $entryListItemsHtml; ?>
        </ul>

        <p class="text-center mt-4">
            <span>&copy; 2020 by </span>
            <a href="https://www.ryanrickgauer.com/resume/index.html" target="_blank">Ryan Rickgauer</a>
        </p>
    </div>


    <?php include('footer.php'); ?>
    <script src="js/home.js"></script>

</body>

</html>
