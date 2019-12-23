## Content

1. [Background](#background)
2. [Function Table](#function-table)
3. [For Loops](#for-loops)

## [Background](#content)

This is going to be an ongoing project where that reviews some functions/code snippets and the different syntax between common programming languages.

## [Function Table](#content)

<table class="table table-sm">
<thead>
<tr>
<th>Functions:</th>
<th>PHP</th>
<th>JavaScript</th>
<th>Python</th>
</tr>
</thead>

<tbody>

<tr>
<th>String length</th>
<td><code>strlen($str)</code></td>
<td><code>str.length</code></td>
<td><code>len(str)</code></td>
</tr>

<tr>
<th>Array size</th>
<td><code>count($array)</code></td>
<td><code>array.length</code></td>
<td><code>len(array)</code></td>
</tr>

<tr>
<th>Creating a function</th>
<td><code>function print()</code></td>
<td><code>function print()</code></td>
<td><code>def function:</code></td>
</tr>
</tbody>
</table>


## [For Loops](#content)

### PHP

```php
for ($x = 0; $x <= 100; $x+=10) {
    echo "The number is: $x";
}
```

### JavaScript

```javascript
for (i = 0; i < len; i++) {
  text += cars[i];
}
```

### Python

#### Looping through a list

```python
fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)
```

#### Looping through string index

```python
for x in "banana":
  print(x)
```

#### Looping through a range

```python
for x in range(6):
  print(x)
```






