
This is a short example on how to use jQuery's `:contains` selector.


## Example


Suppose we have a table like this:


<details>
<summary>Example table</summary>

<table id="data-table">
  <thead><tr><th>First name</th><th>Last name</th><th>Email</th><th>Country</th><th>Dob</th></tr></thead>
  <tbody>
    <tr><td>Johny</td><td>Walker</td><td>johny.walker@whiskey.com</td><td>Scotland</td><td>1/1/1920</td></tr>
    <tr><td>nikhil</td><td>Vartak</td><td>nikhil.vartak@hotmail.co.in</td><td>india</td><td>12/5/1986</td></tr>
    <tr><td>Peter</td><td>James</td><td>james_peter@hotmail.com</td><td>germany</td><td>5/10/1960</td></tr>
    <tr><td>nikhil</td><td>Vartak</td><td>nikhil.vartak@hotmail.com</td><td>india</td><td>11/27/1984</td></tr>
    <tr><td>Peter</td><td>James</td><td>james_peter@hotmail.com</td><td>germany</td><td>5/10/1960</td></tr>
    <tr><td>jack</td><td>Daniel</td><td>j'daniels@whiskey.com</td><td>USA</td><td>1/10/1846</td></tr>
    <tr><td>nikhil</td><td>Vartak</td><td>nikhil.vartak@hotmail.co.in</td><td>india</td><td>12/5/1986</td></tr>
    <tr><td>Peter</td><td>James</td><td>james_peter@hotmail.com</td><td>germany</td><td>5/10/1960</td></tr>
    <tr><td>jack</td><td>Daniel</td><td>j'daniels@whiskey.com</td><td>USA</td><td>1/10/1846</td></tr>
    <tr><td>jack</td><td>Daniel</td><td>j'daniels@whiskey.com</td><td>USA</td><td>1/10/1846</td></tr>
    <tr><td>Mark</td><td>Anderson</td><td>anderson_m@gmail.com</td><td>canada</td><td>2/29/1980</td></tr>
    <tr><td>jack</td><td>Daniel</td><td>j'daniels@whiskey.com</td><td>USA</td><td>1/10/1846</td></tr>
    <tr><td>nikhil</td><td>Vartak</td><td>nikhil.vartak@hotmail.co.in</td><td>india</td><td>12/5/1986</td></tr>
    <tr><td>jack</td><td>Daniel</td><td>j'daniels@whiskey.com</td><td>USA</td><td>1/10/1846</td></tr>
    <tr><td>Peter</td><td>James</td><td>james_peter@hotmail.com</td><td>germany</td><td>5/10/1960</td></tr>
  </tbody>
</table>

</details>


If we have an input, we could use this code to filter the results:

```js

function searchTable() {
    var input = $('#search-input').val();
    $('#data-table').find('tr:not(:contains(' + input + '))').addClass('d-none'); // hide non matches
    $('#data-table').find('tr:contains(' + input + ')').removeClass('d-none');    // show mathing tables
}

```



