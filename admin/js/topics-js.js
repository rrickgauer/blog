const API = 'api.blog.php';

//////////
// Main //
//////////
$(document).ready(function() {
  getTopics(loadTopicsTable);
  addMyListeners();
});


//////////////////////////////
// Adds the event listeners //
//////////////////////////////
function addMyListeners() {
  $('#table-topics').on('click', '.btn-delete-topic', function() {
    deleteTopic(this);
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

///////////////////////////////////////////
// Retrieves all the topics from the API //
///////////////////////////////////////////
function getTopics(action) {
  var data = {
    function: 'get-topics'
  }

  $.getJSON(API, data, function(response) {
    action(response);
  })
  .fail(function(response) {
    displayAlert('There was an error fetching topics from API');
    return;
  });
}

////////////////////////////////////////////
// Loads the topics into the topics-table //
////////////////////////////////////////////
function loadTopicsTable(topics) {
  var html = '';
  const size = topics.length;

  for (var count = 0; count < size; count++) 
    html += getTopicTableRowHtml(topics[count]);

  $('#table-topics tbody').html(html);
  loadAllTableText();
}

/////////////////////////////////////////////
// Returns the html for a topics-table row //
/////////////////////////////////////////////
function getTopicTableRowHtml(topic) {
  var html = `
  <tr class="topic-row" data-topic-id="${topic.id}">
      <td class="topic-row-id">${topic.id}</td>
      <td class="topic-row-name">${topic.name}</td>
      <td class="topic-row-count">${topic.count}</td>
      <td class="topic-row-action"><button class="btn btn-sm btn-delete-topic"><i class='bx bx-trash'></i></button></td>
  </tr>`;

  return html;
}

////////////////////
// Delete a topic //
////////////////////
function deleteTopic(btn) {
  var topicRow = $(btn).closest('.topic-row');
  var topicID = $(topicRow).attr('data-topic-id');

  // don't delete if count > 0
  if ($(topicRow).find('.topic-row-count').text() != '0') {
    alert('Cannot delete used topic.');
    return;
  }

  // confirm that I want to delete the topic
  if (!confirm('Are you sure you want to delete this topic?'))
    return;

  var data = {
    function: "delete-topic",
    topicID: topicID
  }

  $.post(API, data, function(response) {
    $(topicRow).remove();
    displayAlert('Topic successfully deleted');
    return;
  })
  .fail(function(response) {
    displayAlert('Error! Topic was not deleted');
    return;
  });
}