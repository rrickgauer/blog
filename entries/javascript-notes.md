# Javascript Notes
This post is going to be like my php notes page, but with javascript. My goal is to be adding to this whenever I can.


## New page

```javascript
window.location.href = "http://example.com/";
```

## Ajax

```javascript
function completeAllListItems() {
  var xhttp = new XMLHttpRequest();

  xhttp.onreadystatechange = function() {
   if (this.readyState == 4 && this.status == 200) {
  	 var e = this.responseText;
  	 $("#todo-list-section").html(e);
   }
  };

  var listID = $("#todo-list-card").attr("data-listid");
  var link = 'complete-all-list-items.php?listID=' + listID;

  xhttp.open("GET", link, true);
  xhttp.send();
}
```
