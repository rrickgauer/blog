<?php include('functions.php'); ?>
<?php include('Parsedown.php'); ?>
<!DOCTYPE html>
<html lang="en" dir="ltr">

<head>
  <?php include('header.php'); ?>
  <title></title>
</head>

<body>

  <div class="wrapper">


    <!-- Sidebar -->
    <nav id="sidebar">
      <div class="sidebar-header">
        <h3>Bootstrap Sidebar</h3>
      </div>

      <ul class="list-unstyled components">
        <p>Dummy Heading</p>
        <li>
          <a href="#">About</a>
        </li>
        <li>
          <a href="#">Portfolio</a>
        </li>
        <li>
          <a href="#">Contact</a>
        </li>

        <?php

        $count = 0;
        while ($count < 100) {

          echo '<li>
          <a href="#">Contact</a>
        </li>';


          $count++;
        }




        ?>


      </ul>

    </nav>
    <!-- Page Content -->
    <div id="data">

      <button type="button" id="sidebarCollapse" class="btn btn-info">
            <i class="fas fa-align-left"></i>
            <span>Toggle Sidebar</span>
          </button>

      

      <?php

          $count = 0;

          while ($count < 20) {

            echo '<h1>Hello</h1>';

            $count++;
          }



          ?>

    </div>
  </div>


<script>
$(document).ready(function () {

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('#data').toggleClass('active');
    });

});
</script>










</body>

</html>
