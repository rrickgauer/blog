# TableSort Example

## Docs

* [GitHub repo](https://github.com/tristen/tablesort)
* [Demo](http://tristen.ca/tablesort/demo/)
* [Complete example gist](https://gist.github.com/rrickgauer/39fed29080d4d36f7ff1b29c4d780eb8)

---

**Include the table sort files in your HTML file:**

```html
<!-- core -->
<script type="text/javascript" src="tablesort.min.js"></script>

<!-- additional libraries -->
<script type="text/javascript" src="tablesort.date.min.js"></script>
<script type="text/javascript" src="tablesort.number.min.js"></script>
```

**Setup your html table:**

```html
<table class="table table-bordered table-hover table-condensed" id="mytable">
    <thead>
      <tr>
          <th data-sort-method="number">id</th>
          <th>first_name</th>
          <th>last_name</th>
          <th>email</th>
          <th data-sort-method="date">date</th>
          <th data-sort-method="number">amount</th>
      </tr>
    </thead>

    <!-- tbody rows -->
</table>
```

**In your personal JavaScript file execute:**

```js
new Tablesort(document.getElementById('table'));
```

**Then, you can click on a table column header and it will sort by that.**

