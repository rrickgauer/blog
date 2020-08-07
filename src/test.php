<?php include('functions.php'); ?>
<?php include('Parsedown.php'); ?>

<!DOCTYPE html>
<html>
<head>
    <?php include('header.php'); ?>
    <title>test</title>
</head>
<body>

    <div class="container">

        <h1>Test</h1>

        <div id="stars">
            <ul class="list-group list-group-flush"></ul>
        </div>





    </div>

    <script>

        const API = 'https://api.github.com/users/rrickgauer/starred';
        const link = 'https://api.github.com/user/22210580/starred?page=2'
        var links = [];
        var lastPage = 1;

        $(document).ready(function() {
            getStars();
        });

        function getStars() {
            $.getJSON(API, function(response, status, xhr) {
                // displayStars(response);
                getLastPage(xhr.getResponseHeader("link"));
                loadLinks();
                getStarsData();
            });
        }

        function displayStars(stars) {
            var html = '';

            for (var count = 0; count < stars.length; count++) {
                html += '<li class="list-group-item">';
                html += '<a target="_blank" href="' + stars[count].url + '">';
                html += '<b>' + stars[count].name + '</b> &mdash; ';
                html += stars[count].description + '</a></li>';
            }

            $("#stars .list-group").append(html);
        }

        function getLastPage(link) {
            var ar = link.split(",");          // Split on commas
            ar[1] = ar[1].trim();
            var newPage = ar[1].split("=");
            lastPage = parseInt(newPage[1].charAt(0));
            // loadLinks();
        }

        function loadLinks() {
            for (var count = 1; count <= lastPage; count++) {
                var newLink = 'https://api.github.com/user/22210580/starred?page=' + count.toString();
                links.push(newLink);
            }
        }

        function getStarsData() {
            for (var count = 0; count < links.length; count++) {
                $.getJSON(links[count], function(response) {
                    displayStars(response);
                });
            }
        }


    </script>

</body>
</html>