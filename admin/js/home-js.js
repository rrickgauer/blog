const API             = 'api.blog.php';
const entryTable      = $('.table-entries');
const modalEntryEdit  = $('#modal-entry-edit');
const GITHUB_URL      = 'https://api.github.com/repos/rrickgauer/blog/contents/entries/';
const GITHUB_AUTH     = 'token d5df00aa6482edcc03d419de2e660d90e6c25fbb';
const BLOG_ENTRY_LINK = 'https://www.ryanrickgauer.com/blog/entries.php?entryID=';

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
  // getGithubEntryFiles(loadGithubEntries);
  getUsedTopics(displayUsedTopicsOptions);
});


//////////////////////////////////////////////////////
// Adds all the event listeners on inital page load //
//////////////////////////////////////////////////////
function addMyListeners() {
  $('.table-entries tbody').on('click', '.table-entries-row', function() {
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

  $('#select-entry-file').on('change', setNewEntryLinkValue);

  $('.btn-delete-entry').on('click', deleteEntry);

  $('#filter-topics').on('change', filterTopics);
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
    console.log(response.responseText);
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
  var html = '<tr class="table-entries-row" data-entry-id="' + entry.id + '" data-topic="' + entry.topic_name + '">';

  html += getEntryTableCellHtml(entry.id, 'entry-id');
  html += getEntryTableCellHtml(entry.title, 'entry-title');
  html += getEntryTableCellHtml(entry.date_display, 'entry-date');
  html += getEntryTableCellHtml(entry.topic_name, 'entry-topic');

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
function openEntryModal(row) {
  var entryID = $(row).attr('data-entry-id');

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
  $('#edit-entry-topic option[value="' + entry.topic_id + '"]').prop('selected', true);

  // set date
  flatpickr("#edit-entry-date", {
    altInput: true,
    altFormat: "F j, Y",
    dateFormat: "Y-m-d",
    maxDate: "today",
    defaultDate: entry.date_raw,
  });

  // set the hrefs of the links
  $(modalEntryEdit).find('.btn-link-source').attr('href', entry.link);
  $(modalEntryEdit).find('.btn-link-post').attr('href', BLOG_ENTRY_LINK + entry.id);

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
  displayAlert('Entry updated successfully');
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
    topicID: $('#edit-entry-topic').val(),
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

/////////////////////////////////////////
// Retrieve all the github entry files //
/////////////////////////////////////////
function getGithubEntryFiles(action) {
  var data = {
    Authorization: GITHUB_AUTH,
  }

  $.getJSON(GITHUB_URL, data, function(response) {
    action(response);
  })
  .fail(function(response) {
    displayAlert('Error. Could not fetch entries from Github');
  });
}

////////////////////////////////////////////////
// Load the entry files retrieved from github //
////////////////////////////////////////////////
function loadGithubEntries(entries) {
  // sort the entries
  entries.sort(function(a, b) {
    return (a.name.toUpperCase() < b.name.toUpperCase()) ? -1 : 1;
  });
  
  // create html
  var optionsHtml = '';
  for (var count = 0; count < entries.length; count++)
    optionsHtml += getEntrySelectOptionHtml(entries[count]);

  $('#select-entry-file').append(optionsHtml);
}

////////////////////////////////////////////////////
// Return the html for github entry select option //
////////////////////////////////////////////////////
function getEntrySelectOptionHtml(entry) {
  return `<option value="${entry.download_url}">${entry.name}</option>`;
}


///////////////////////////////////////////////////////////////
// Set the link value to the selection option of the entries //
///////////////////////////////////////////////////////////////
function setNewEntryLinkValue() {
  var selectValue = $('#select-entry-file option:checked').val();
  $('#new-entry-link').val(selectValue);
}


//////////////////////
// Delete the entry //
//////////////////////
function deleteEntry() {
  // confirm that I want to delete the entry
  if (!confirm('Are you sure you want to delete this entry?'))
    return;

  var entryID = $('#modal-entry-edit').attr('data-entry-id');
  var data = {
    function: "delete-entry",
    entryID: entryID,
  }

  $.post(API, data, function(response) {
    // remove the entry from the table
    var entryRow = getEntryTableRowElement(entryID);
    $(entryRow).remove();

    // close the modal
    $('#modal-entry-edit').modal('hide');

    // display message
    displayAlert('Entry was deleted');
  })
  .fail(function(response) {
    displayAlert('Error. Entry was not deleted.');
    return;
  });
}

//////////////////////////////////////
// Get the used topics from the api //
//////////////////////////////////////
function getUsedTopics(action) {

  var data = {
    function: "get-used-topics",
  }

  $.getJSON(API, data, function(response) {
    action(response);
  })
  .fail(function(response) {
    displayAlert('Error fetching used distinct topics from db!');
    return;
  });
}

//////////////////////////////////
// Display the used topics html //
//////////////////////////////////
function displayUsedTopicsOptions(topics) {
  var html = '';
  for (var count = 0; count < topics.length; count++)
    html += getUsedTopicSelectHtml(topics[count]);


  $('#filter-topics .custom-topic').remove();
  $('#filter-topics').append(html);
}

///////////////////////////////////////////////
// Generate a used topic select html element //
///////////////////////////////////////////////
function getUsedTopicSelectHtml(topic) {
  return `<option class="custom-topic" value="${topic.name}">${topic.name}</option>`;
}

///////////////////////
// Filter the topics //
///////////////////////
function filterTopics() {
  var filterTopics = $('#filter-topics');
  var topic = $(filterTopics).find('option:checked').val();

  // show all topics if the all option is selected
  if (topic == 'SHOW_ALL') {
    $('.table-entries-row').show();
    return;
  }

  // hide all topics first
  $('.table-entries-row').hide();

  // show the ones with the topic
  $('.table-entries-row[data-topic="' + topic + '"]').show();
}
