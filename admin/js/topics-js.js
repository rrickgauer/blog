const API = 'api.blog.php';

//////////
// Main //
//////////
$(document).ready(function() {
  getTopics(loadTopicsTable);
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
  <tr>
      <td>${topic.id}</td>
      <td>${topic.name}</td>
      <td>${topic.count}</td>
  </tr>`;

  return html;
}