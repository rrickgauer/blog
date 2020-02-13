<?php
include('functions.php');
include('Parsedown.php');

if (isset($_GET['entryID'])) {
  $entry = getEntry($_GET['entryID']);
}
?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>
  <?php
  if (isset($_GET['entryID'])) {
    echo '<title>' . $entry['title'] . '</title>';
  } else {
    echo '<title>Ryan Rickgauer&apos;s Blog</title>';
  }
  ?>

</head>

<body>

  <div class="wrapper">

    <!-- sidebar  -->
    <div id="sidebar" class="active">
      <div class="sidebar-search">
        <div class="input-group input-group-sm">
          <input type="text" class="form-control" id="entry-search" aria-label="Search input" placeholder="Search" onkeyup="filterEntries()">
          <div class="input-group-append" id="entry-search-icon">
            <span class="input-group-text"><i class='bx bx-search'></i></span>
          </div>
        </div>
      </div>

      <!-- entries list -->
      <ul class="list-unstyled" id="nav-list">
        <?php
        $entries = getAllEntries();
        while ($entry = $entries->fetch(PDO::FETCH_ASSOC)) {
          $id = $entry['id'];
          $title = $entry['title'];
          echo "<li class=\"sidebar-li\"><a class=\"sidebar-link\" href=\"entries.php?entryID=$id\">$title</a></li>";
        }
        ?>
      </ul>
    </div>



    <div id="data" class="container-fluid">
      <button id="show-entries" class="hamburger hamburger--elastic" type="button">
        <span class="hamburger-box">
          <span class="hamburger-inner"></span>
        </span>
      </button>

      <script>
        var $hamburger = $(".hamburger");
        $hamburger.on("click", function(e) {
          $hamburger.toggleClass("is-active");
        });
      </script>

      <?php

      if (isset($_GET['entryID'])) {
        $entry = getEntry($_GET['entryID']);
        echo '<h1 class="custom-font post-title">' . $entry['title'] . '</h1>';
        echo '<h6 class="text-center entry-date">' . $entry['date'] . '</h6>';
        $Parsedown = new Parsedown();
        echo $Parsedown->text($entry['content']);
      }

      else {
        include('home.php');
      }

      ?>

      <script>
        new TypeIt('.custom-font', {
          speed: 50,
          startDelay: 900
        })
        .options({speed: 50})

        .go();
      </script>

      <div id="home-footer">
        <a href="https://github.com/rrickgauer/blog" target="_blank"><i class='bx bxl-github'></i></a>
      </div>

    </div>
  </div>

  <script src="js/prism.js"></script>

  <script>
    $(document).ready(function() {
      // set all links to open in a new tab
      $("#data a").attr("target", "_blank");
      
      $("#show-entries").on("click", function() {
        $('#sidebar').toggleClass('active');
        $('#data').toggleClass('active');

        // clears search box and list all entries
        $("#entry-search").val('');
        filterEntries();
      });
    });



    function filterEntries() {
      // get search query
      var filter = $("#entry-search").val().toUpperCase();
      var ul = $("#nav-list");
      var li = $(".sidebar-li");

      if (filter.length == 0) {
        setSearchIcon();
      } else {
        setClearButton();
      }

      // get list items
      var a = $(".sidebar-link");

      for (var count = 0; count < li.length; count++) {

        a = li[count].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;

        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          li[count].style.display = "";
        } else {
          li[count].style.display = "none";
        }
      }
    }

    function setClearButton() {
      $("#entry-search-icon").html('<button class="btn btn-outline-secondary" type="button" onclick="resetEntrySearch()"><i class="bx bx-x"></i></button>');
    }

    function setSearchIcon() {
      $("#entry-search-icon").html('<span class="input-group-text"><i class="bx bx-search"></i></span>');
    }

    function resetEntrySearch() {
      clearEntrySearch();
      filterEntries();
    }

    function clearEntrySearch() {
      $("#entry-search").val('');
    }
  </script>


</body>

</html>
