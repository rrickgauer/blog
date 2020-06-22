# MySQL Notes

## Dates

### Date_Format()

Use ```DATE_FORMAT()``` to modify the looks of dates.

```sql
DATE_FORMAT(date, format)
```

#### Formats
<table>
  <thead>
    <tr>
      <th>Format</th>
      <th>Description</th>
    </tr> 
  </thead>
  <tbody> 
  <tr>
    <td>%a</td>
    <td>Abbreviated weekday name (Sun to Sat)</td>
  </tr>
  <tr>
    <td>%b</td>
    <td>Abbreviated month name (Jan to Dec)</td>
  </tr>
  <tr>
    <td>%c</td>
    <td>Numeric month name (0 to 12)</td>
  </tr>
  <tr>
    <td>%D</td>
    <td>Day of the month as a numeric value, followed by suffix (1st, 2nd, 3rd, ...)</td>
  </tr>
  <tr>
    <td>%d</td>
    <td>Day of the month as a numeric value (01 to 31)</td>
  </tr>
  <tr>
    <td>%e</td>
    <td>Day of the month as a numeric value (0 to 31)</td>
  </tr>
  <tr>
    <td>%h</td>
    <td>Hour (00 to 12)</td>
  </tr>
  <tr>
    <td>%I</td>
    <td>Hour (00 to 12)</td>
  </tr>
  <tr>
    <td>%i</td>
    <td>Minutes (00 to 59)</td>
  </tr>

  <tr>
    <td>%l</td>
    <td>Hour (1 to 12)</td>
  </tr>
  <tr>
    <td>%M</td>
    <td>Month name in full (January to December)</td>
  </tr>
  <tr>
    <td>%m</td>
    <td>Month name as a numeric value (00 to 12)</td>
  </tr>
  <tr>
    <td>%p</td>
    <td>AM or PM</td>
  </tr>
  <tr>
    <td>%r</td>
    <td>Time in 12 hour AM or PM format (hh:mm:ss AM/PM)</td>
  </tr>
  <tr>
    <td>%S</td>
    <td>Seconds (00 to 59)</td>
  </tr>
  <tr>
    <td>%s</td>
    <td>Seconds (00 to 59)</td>
  </tr>
  <tr>
    <td>%W</td>
    <td>Weekday name in full (Sunday to Saturday)</td>
  </tr>
  <tr>
    <td>%Y</td>
    <td>Year as a numeric, 4-digit value</td>
  </tr>
  <tr>
    <td>%y</td>
    <td>Year as a numeric, 2-digit value</td>
  </tr>
</tbody>
</table>

Additional options can be found [here](https://dev.mysql.com/doc/refman/8.0/en/date-and-time-functions.html#function_date-format).

#### Common examples

| Code | Result |
| :------ | :--- |
| ```DATE_FORMAT(date, "%l:%i %p")``` | 5:23 PM |
| ```DATE_FORMAT(date, "%c/%d/%Y")``` | 4/12/1996 |
| ```DATE_FORMAT(date, "%M %D %Y")``` | June 15th 2017 |