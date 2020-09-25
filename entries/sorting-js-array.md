This is how to sort a list of jQuery objects by using JavaScript's ```sort()``` function.

Here is the [documentation](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/sort) for it.

## Example

Let's say you have a table

| Full Name           | Country           | Created At                                                | Id | Email                          |
|---------------------|-------------------|-----------------------------------------------------------|----|--------------------------------|
| Creola McClure      | Panama Canal Zone | Sun May 26 2019 04:07:05 GMT-0500 (Central Daylight Time) | 0  | Laverna@noelia.com             |
| Mrs. John Bahringer | Lebanon           | Thu Oct 06 1988 09:45:25 GMT-0500 (Central Daylight Time) | 1  | Juliet.OKeefe@sheila.tv        |
| Eryn O'Kon          | Colombia          | Sun May 14 2017 20:17:55 GMT-0500 (Central Daylight Time) | 2  | Kenyatta.Schultz@laurianne.tv  |
| Delilah Murphy      | Vanuatu           | Wed Aug 14 2002 20:35:15 GMT-0500 (Central Daylight Time) | 3  | Immanuel@adelbert.net          |
| Toy Blanda          | Qatar             | Wed May 03 2000 01:48:55 GMT-0500 (Central Daylight Time) | 4  | Daisha_Hettinger@audreanne.org |
| May Prohaska        | French Guiana     | Sat Jan 03 1987 10:46:04 GMT-0600 (Central Standard Time) | 5  | Keegan@giuseppe.com            |
| Aditya Flatley      | Ghana             | Thu Feb 04 1988 04:05:33 GMT-0600 (Central Standard Time) | 6  | Brice@al.name                  |
| Retha Klein PhD     | Oman              | Mon Jul 21 1986 13:02:16 GMT-0500 (Central Daylight Time) | 7  | Nathanial@angelo.biz           |
| Scot Tillman PhD    | Tokelau           | Sat Feb 12 2005 17:41:17 GMT-0600 (Central Standard Time) | 8  | Lisette_McGlynn@charles.co.uk  |
| Jayce Klocko        | Kiribati          | Thu Nov 05 1998 22:04:55 GMT-0600 (Central Standard Time) | 9  | Rhianna_Keebler@mateo.co.uk    |



<details>
  <summary>Click to see code</summary>


```html
<table>
<thead>
  <tr>
    <th>Full Name</th>
    <th>Country</th>
    <th>Created At</th>
    <th>Id</th>
    <th>Email</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="full-name">Creola McClure</td>
    <td>Panama Canal Zone</td>
    <td>Sun May 26 2019 04:07:05 GMT-0500 (Central Daylight Time)</td>
    <td class="id">0</td>
    <td class="email">Laverna@noelia.com</td>
  </tr>
  <tr>
    <td class="full-name">Mrs. John Bahringer</td>
    <td>Lebanon</td>
    <td>Thu Oct 06 1988 09:45:25 GMT-0500 (Central Daylight Time)</td>
    <td class="id">1</td>
    <td class="email">Juliet.OKeefe@sheila.tv</td>
  </tr>
  <tr>
    <td class="full-name">Eryn O'Kon</td>
    <td>Colombia</td>
    <td>Sun May 14 2017 20:17:55 GMT-0500 (Central Daylight Time)</td>
    <td class="id">2</td>
    <td class="email">Kenyatta.Schultz@laurianne.tv</td>
  </tr>
  <tr>
    <td class="full-name">Delilah Murphy</td>
    <td>Vanuatu</td>
    <td>Wed Aug 14 2002 20:35:15 GMT-0500 (Central Daylight Time)</td>
    <td class="id">3</td>
    <td class="email">Immanuel@adelbert.net</td>
  </tr>
  <tr>
    <td class="full-name">Toy Blanda</td>
    <td>Qatar</td>
    <td>Wed May 03 2000 01:48:55 GMT-0500 (Central Daylight Time)</td>
    <td class="id">4</td>
    <td class="email">Daisha_Hettinger@audreanne.org</td>
  </tr>
  <tr>
    <td class="full-name">May Prohaska</td>
    <td>French Guiana</td>
    <td>Sat Jan 03 1987 10:46:04 GMT-0600 (Central Standard Time)</td>
    <td class="id">5</td>
    <td class="email">Keegan@giuseppe.com</td>
  </tr>
</tbody>
</table>

```



</details>




## Sorting


To sort by the Full Name column we could do this:

```js
var rows = $('table tbody tr');

rows.sort(function (a, b) {
  var nameA = $(a).find('.full-name').text().toUpperCase();
  var nameB = $(b).find('.full-name').text().toUpperCase();
  return (nameA < nameB) ? -1 : 1;
});
```

To sort by the ID column you can do this:

```js
var rows = $('table tbody tr');

rows.sort(function (a, b) {
  var idA = parseInt($(a).find('.id').text());
  var idB = parseInt($(b).find('.id').text());
  return (idA < idB) ? -1 : 1;
});
```



<script>
  
$(document).ready(function() {
  $('table').addClass('tablesort');
});

</script>