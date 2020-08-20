
<p>This is a list of my own <a href="https://github.com/rrickgauer?tab=stars">github stars</a></p>

<!-- <div class="input-group">
  <div class="input-group-prepend">
    <span class="input-group-text"><i class='bx bx-search'></i></span>
  </div>
  <input type="email" class="form-control" id="search-input" placeholder="Search...">
</div> -->


<div class="d-flex toolbar">

  <div class="d-flex align-items-center">
    
  <span class="mr-2 text-weight-bold">Languages:</span>

  <select id="select-languages" class="form-control">
  </select>

  </div>
  
</div>

<div id="stars" class="mt-3"></div>



<script>
  const API    = 'https://api.github.com/users/rrickgauer/starred';
  const link   = 'https://api.github.com/user/22210580/starred?page=2'
  var links    = [];
  var lastPage = 1;

  var languages = [];

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
      html += getCardHtml(stars[count]);

      var language = stars[count].language;

      if (!languages.includes(language))
        languages.push(language);
    }

    $("#stars").append(html);
  }



  function getCardHtml(star) {
    var html = '<div class="card"><div class="card-body">';

    // title
    html += '<h3 class="card-title">';
    html += '<a href="' + star.owner.html_url + '">' + star.owner.login + '</a>'; // owner
    html += ' / ';
    html += '<a href="' + star.html_url + '">' + star.name + '</a></h3>';         // repo

    // description
    html += '<p class="card-text">' + star.description + '</p>';

    // footer
    html += '<div class="d-flex align-items-center">';
    html += '<span class="badge badge-secondary badge-language mr-4">' + star.language + '</span>';                              // language
    html += '<span class="mr-4"><i class="bx bx-star"></i><span class="ml-1">' + star.stargazers_count + '</span></span>';   // number of stars
    html += '<span class="mr-4"><i class="bx bx-git-repo-forked"></i><span class="ml-1">' + star.forks + '</span></span>';   // number of forks
    html += '</div>';

    // end card-body and card
    html += '</div></div>'; 

    return html;
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

    setTimeout(function(){ 
      getListOfLanguages();
    }, 3000);

  }

  function getListOfLanguages() {
      
    var html = '';

    for (var count = 0; count < languages.length; count++) {
      html += '<option value="' + languages[count] + '">' + languages[count] + '</option>';
    }

    $("#select-languages").html(html);
  }


    </script>