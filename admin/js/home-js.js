const API            = 'api.blog.php';
const entryTable     = $('.table-entries');
const modalEntryEdit = $('#modal-entry-edit');

// set new date
var newEntryDate = flatpickr("#new-entry-date", {
  altInput: true,
  altFormat: "F j, Y",
  dateFormat: "Y-m-d",
  maxDate: "today",
  defaultDate: "today",
});


///////////////////
// Main function //
///////////////////
$(document).ready(function() {
  getEntries();
  $("#nav-item-home").addClass('active');
  addMyListeners();
});


//////////////////////////////////////////////////////
// Adds all the event listeners on inital page load //
//////////////////////////////////////////////////////
function addMyListeners() {
  $('.table-entries tbody').on('click', '.btn-open-entry-modal', function() {
    openEntryModal(this);
  });

  $(modalEntryEdit).on('hide.bs.modal', function (e) {
    closeModalEntryEdit();
  });

  $('.btn-submit-entry-edit').on('click', function() {
    updateEntry();
  });

  $('.btn-submit-entry-new').on('click', function() {
    insertEntry();
  });
}


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
    loadAllTableText();
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
  var html = '<tr class="table-entries-row" data-entry-id="' + entry.id + '">';

  html += getEntryTableCellHtml(entry.id, 'entry-id');
  html += getEntryTableCellHtml(entry.title, 'entry-title');
  html += getEntryTableCellHtml(entry.date_display, 'entry-date');

  // create the html for the link
  var linkHtml = '<a href="' + entry.link + '" target="_blank">Visit</a>';
  html += getEntryTableCellHtml(linkHtml, 'entry-link');

  // button that opens the edit entry modal
  var editCellHtml = '<td><button class="btn btn-sm btn-open-entry-modal">';
  editCellHtml += '<i class="bx bxs-pencil"></i></button></td>';
  html += editCellHtml;

  html += '</tr>';

  return html;
}

/////////////////////////////////////////////
// Creates the html for a entry table cell //
/////////////////////////////////////////////
function getEntryTableCellHtml(value, className) {
  return '<td class="' + className + '">' + value + '</td>';
}

///////////////////////////////////////////
// Retrieves the entry data from the api //
///////////////////////////////////////////
function openEntryModal(btn) {
  var entryID = $(btn).closest('.table-entries-row').attr('data-entry-id');

  var data = {
    function: "get-entry",
    entryID: entryID,
  }

  $.getJSON(API, data, function(response) {
    displayEntryModal(response);
  })
  .fail(function(response) {
    displayAlert(response);
  });
}

/////////////////////////////////////////
// Loads the data into the form inputs //
// Opens the modal for view            //
/////////////////////////////////////////
function displayEntryModal(entry) {
  // set the entry id in the modal
  $(modalEntryEdit).attr('data-entry-id', entry.id);

  // set input values
  $('#edit-entry-title').val(entry.title);
  $('#edit-entry-link').val(entry.link);

  // set date
  flatpickr("#edit-entry-date", {
    altInput: true,
    altFormat: "F j, Y",
    dateFormat: "Y-m-d",
    maxDate: "today",
    defaultDate: entry.date_raw,
  });

  // display the modal
  $(modalEntryEdit).modal('show');
}

/////////////////////////////////////////////////////
// Clears the input values in the edit entry modal //
/////////////////////////////////////////////////////
function closeModalEntryEdit() {
  $(modalEntryEdit).find('input').val('');
}

///////////////////////////
// Updates an entry data //
///////////////////////////
function updateEntry() {
  var data = getEditEntryInputValues();

  $.post(API, data).fail(function(response) {
    displayAlert('Error updating the entry');
    return;
  });

  updateEntriesTableRow(data.entryID);
  closeModalEntryEdit();
}

/////////////////////////////////////////////////
// Returns the edit modal input values in json //
/////////////////////////////////////////////////
function getEditEntryInputValues() {
  var data = {
    function: "update-entry",
    entryID: $(modalEntryEdit).attr('data-entry-id'),
    title: $('#edit-entry-title').val(),
    link: $('#edit-entry-link').val(),
    date: $('#edit-entry-date').val(),
  }

  return data;
}

/////////////////////////////////////////////////////////
// updates the entry row to the current data in the db //
/////////////////////////////////////////////////////////
function updateEntriesTableRow(entryID) {
  var data =  {
    function: 'get-entry',
    entryID: entryID,
  }

  $.getJSON(API, data, function(response) {
    var currentRow = getEntryTableRowElement(entryID);
    var newRowHtml = getEntryTableRowHtml(response);
    $(currentRow).replaceWith(newRowHtml);
    $(modalEntryEdit).modal('hide');
  });

}

////////////////////////////////////////////////
// Returns the entry row element in the table //
////////////////////////////////////////////////
function getEntryTableRowElement(entryID) {
  return $('.table-entries-row[data-entry-id="' + entryID + '"]');
}