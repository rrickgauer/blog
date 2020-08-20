
This is a list of my own [github stars](https://github.com/rrickgauer?tab=stars)

<div class="input-group">
  <div class="input-group-prepend">
    <span class="input-group-text"><i class='bx bx-search'></i></span>
  </div>
  <input type="email" class="form-control" id="search-input" placeholder="Search...">
</div>


<div class="table-responsive">
  <table class="table" id="stars">
    <thead>
      <tr>
        <th data-sort-default>Repository</th>
        <th>Description</th>
        <th>Link</th>
      </tr>
    </thead>
    <tbody>
    </tbody>
  </table>
</div>

<script>
  const API    = 'https://api.github.com/users/rrickgauer/starred';
  const link   = 'https://api.github.com/user/22210580/starred?page=2'
  var links    = [];
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
      new TableSearch('search-input', 'stars').init();
      
    });
  }

  function displayStars(stars) {
    var html = '';

    for (var count = 0; count < stars.length; count++) {
      html += '<tr>';
      html += '<td>' + stars[count].name + '</td>';
      html += '<td>' + stars[count].description + '</td>';
      html += '<td><a href="' + stars[count].html_url + '">Visit</a></td>';
      html += '</tr>';
    }

    $("#stars tbody").append(html);
    new TableSearch('search-input', 'stars').init();
    
  }

  function getLastPage(link) {
    var ar = link.split(",");          // Split on commas
    ar[1] = ar[1].trim();
    var newPage = ar[1].split("=");
    lastPage = parseInt(newPage[1].charAt(0));
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

    new Tablesort(document.getElementById('stars'));
  }


    </script>