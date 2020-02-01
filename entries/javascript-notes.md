# Javascript Notes
This post is going to be like my [PHP Notes page](https://www.ryanrickgauer.com/blog/entries.php?entryID=32). I will be adding to it periodically. If you have any comments or suggestions, don't hesitate to email me.

## Content
1. [New Page](#new-page)
2. [Ajax](#ajax)


## New page

```javascript
window.location.href = "http://example.com/";
```

## Ajax

### Sending a request

#### XMLHttpRequest

```javascript
function completeAllListItems() {
  var xhttp = new XMLHttpRequest();

  xhttp.onreadystatechange = function() {
   if (this.readyState == 4 && this.status == 200) {
  	 var e = this.responseText;
  	 $("#todo-list-section").html(e);    // html section where the updated content is placed
   }
  };

  var listID = $("#todo-list-card").attr("data-listid");
  var link = 'complete-all-list-items.php?listID=' + listID;

  xhttp.open("GET", link, true);
  xhttp.send();
}
```

#### jQuery

```javascript
$.ajax({
  type: "GET",
  url: 'get-data.php',
  data: {
    "id": 1,
    "name": "John"
  },
  success: function(response) {
    loadData(response);   // function
  }
});
```

### Receiving the response

Once the php file receives the request from the file, it may sometimes return only data in a JSON format. If so, this is how you would parse the data returned by the php file:

```javascript
var data = JSON.parse(response);
```
