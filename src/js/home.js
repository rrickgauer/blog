
const SORT_OPTIONS = {
  DATE: "date",
  TITLE: "title",
};


//////////
// main //
//////////
$(document).ready(function() {
  addEventListeners();
  initTypeIt();
});


function addEventListeners() {
  $('.select-sort').on('change', sortEntries);
}


function initTypeIt() {
  new TypeIt('.custom-font', {
    speed: 50,
    startDelay: 900
  })
  .options({speed: 50})
  .go();
}


function sortEntries() {
  var sortOption = $('.select-sort').val();

  if (sortOption == SORT_OPTIONS.DATE)
    sortEntriesByDate();
  else
    sortEntriesByTitle();
}


function sortEntriesByDate() {
  var entries = $('.entry');

  entries.sort(function(a, b) {
    var dateA = $(a).attr('data-date');
    var dateB = $(b).attr('data-date');

    return (parseInt(dateA) > parseInt(dateB)) ? -1 : 1;
  });

  $('.list-group').html(entries);
}

function sortEntriesByTitle() {
  var entries = $('.entry');

  entries.sort(function(a, b) {
    var titleA = $(a).find('.title a').text().toUpperCase();
    var titleB = $(b).find('.title a').text().toUpperCase();

    return (titleA < titleB) ? -1 : 1;
  });

  $('.list-group').html(entries);
}


