This post is going to be like my [PHP Notes page](https://www.ryanrickgauer.com/blog/entries.php?entryID=32). I will be adding to it periodically. If you have any comments or suggestions, don't hesitate to email me.

## Content

1. [New Page](#new-page)
1. [Ajax](#ajax)
1. [New Tab Links](#new-tab-links)
1. [URL Parameters](#url-parameters)
1. [Checked Radio Input Value](#checked-radio-input-value)
1. [String Literals](#string-literals)



## New page

To send the browser to a different page

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

##### .get() & .post()

The ```.get()``` and ```.post()``` functions have the same parameters: ```$.get(url, data, success(response))```. Remember the data variable should be in JSON format.

```javascript
var data = {
  id: 14,
  name: 'Ryan',
}

$.get('example-server.php', data, function(response) {
  console.log(JSON.parse(response));
});
```

### Receiving the response

Once the php file receives the request from the file, it may sometimes return only data in a JSON format. If so, this is how you would parse the data returned by the php file:

```javascript
var returnData = JSON.parse(response);
```
## New Tab Links

To make links open in a new tab using JavaScript, use the following code:
```javascript
$("a").attr("target", "_blank");
```

## URL Parameters
When using JavaScript, one can get the values of a URL by creating a ```URLSearchParams``` object. More info can be found [here](https://www.sitepoint.com/get-url-parameters-with-javascript/).

For example, suppose the url is the following: **example.com?name=ryan&age=24**. To get the values of ```name``` and ```age```, do the following:
```javascript
var queryString = window.location.search;
var urlParams = new URLSearchParams(queryString);
var name = urlParams.get('name');                   // name
var age = urlParams.get('age');                     // age

```


## Checked Radio Input Value

To do this, we are going to use jQuery's [:checked selector](https://api.jquery.com/checked-selector/). The `:checked` selector only words for checkboxes, radio buttons, and options of `select` elements.

To get the value of a checked radio button with a name of `radio-input` you can do:

```js
var radioInputValue = $('input[name="radio-input"]:checked').val();
```


## String Literals

String literals are an easy way to generate an html element with JavaScript variables. You can read more about it from [this article](https://css-tricks.com/html-templates-via-javascript-template-literals/).

To use a string literal, you can do the following:

```js
const some_html = `
  <div class="module">
    <h2>${data.title}</h2>
    <p>${data.content}</p>
  </div>`;
```
