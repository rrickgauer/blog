The [Fetch API](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch) provides a JavaScript interface for accessing and manipulating parts of the HTTP pipeline, such as requests and responses. It also provides a global `fetch()` method that provides an easy, logical way to fetch resources asynchronously across the network.

## Implementation

To use the `fetch` api:

```js
async function postData(url = '', data = {}) {
    const response = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        
        headers: {
          'Content-Type': 'application/json'
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });

    return response;
}
```

## Usage

The fetch method returns a [Response](https://developer.mozilla.org/en-US/docs/Web/API/Response) object:

```js
// response
const apiResponse = await postData({
    name: 'Ryan Rickgauer',
    college: 'Northern Illinois University',
});
```


To check if the request was successful:

```js
if (apiResponse.ok) {
    console.log('Successful request');
} 
else {
    console.log('Request was not successful!');
}
```


If the response returns some json data, you can retrieve it by using the `json()` method:

```js
const responseData = await apiResponse.json();
console.log(responseData);
```
