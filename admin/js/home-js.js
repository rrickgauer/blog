const API        = 'api.blog.php';
const entryTable = $('.table-entries');


///////////////////
// Main function //
///////////////////
$(document).ready(function() {
  $("#nav-item-home").addClass('active');
  getEntries();
});


/////////////////////////////////////
// Displays an alert on the screen //
/////////////////////////////////////
function displayAlert(text) {
  $.toast({
    text: text,
    position: 'bottom-center',
    loader: false,
    bgColor: '#3D3D3D',
    textColor: 'white'
  });
}

////////////////////////////////////////////////
// Retrieve all the entries from the database //
////////////////////////////////////////////////
function getEntries() {
  var data = {
    function: 'get-entries',
  }

  $.getJSON(API, data, function(response) {
    loadEntries(response);
  })
  .fail(function(response) {
    displayAlert('There was an error in the API. get-entries');
  });
}

/////////////////////////////////////////////
// Load all the entries in the entry table //
/////////////////////////////////////////////
function loadEntries(entries) {
  var html = '';

  for (var count = 0; count < entries.length; count++)
    html += getEntryTableRowHtml(entries[count]);

  $(entryTable).find('tbody').html(html);
}

/////////////////////////////////////
// Return the html for a table row //
/////////////////////////////////////
function getEntryTableRowHtml(entry) {
  var html = '<tr data-entry-id="' + entry.id + '">';

  html += getEntryTableCellHtml(entry.id, 'entry-id');
  html += getEntryTableCellHtml(entry.title, 'entry-title');
  html += getEntryTableCellHtml(entry.date_display, 'entry-date');

  // create the html for the link
  var linkHtml = '<a href="' + entry.link + '" target="_blank">Visit</a>';
  html += getEntryTableCellHtml(linkHtml, 'entry-link');

  html += '</tr>';

  return html;
}

/////////////////////////////////////////////
// Creates the html for a entry table cell //
/////////////////////////////////////////////
function getEntryTableCellHtml(value, className) {
  return '<td class="' + className + '">' + value + '</td>';
}
