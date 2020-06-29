This is an example of how to search for values within an HTML table by using the [HTML Table Search](https://github.com/rrickgauer/html-table-search-js) library. I forked the searching JavaScript code from [here](https://github.com/niksofteng/html-table-search-js). A [demo page](https://niksofteng.github.io/html-table-search-js/) is provided by the original author.

## Requirements

Be sure to download and include the JavaScript [source file](https://raw.githubusercontent.com/rrickgauer/html-table-search-js/master/tablesearch.js).

## Example

Say you have in your ```index.html``` file the following table:

```html
<!-- search box -->
<input type="text" id="table-search-input">

<!-- table -->
<table id="mytable">
  <thead>
    <tr>
        <th>id</th>
        <th>first_name</th>
        <th>last_name</th>
        <th>email</th>
        <th>date</th>
        <th>amount</th>
    </tr>
  </thead>
  <tbody>
    <tr>
        <td>1</td>
        <td>Lionello</td>
        <td>Cavanagh</td>
        <td>lcavanagh0@theglobeandmail.com</td>
        <td>1/29/2020</td>
        <td>176.18</td>
    </tr>
    <tr>
        <td>2</td>
        <td>Emmi</td>
        <td>Gill</td>
        <td>egill1@yellowbook.com</td>
        <td>4/23/2020</td>
        <td>192.69</td>
    </tr>
    <tr>
        <td>3</td>
        <td>Heath</td>
        <td>Surmeyer</td>
        <td>hsurmeyer2@samsung.com</td>
        <td>8/18/2019</td>
        <td>241.93</td>
    </tr>
  </tbody>
</table>
```

The tablesearch arguments are as follows:

```js
new TableSearch(searchBoxId, dataTableId [, options]).init();
```

For the example, you could use the following code to activate the table search:

```js
new TableSearch('table-search-input', 'mytable').init();
```

At the bottom of your html code be sure to include the JavaScript files:

```html
<!-- table search -->
<script type="text/javascript" src="tablesearch.js"></script>

<script>
  new TableSearch('table-search-input', 'mytable').init();
</script>
```
