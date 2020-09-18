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


## Data Types

[Source](https://www.w3schools.com/sql/sql_datatypes.asp)



<details>
  <summary>String Data Types</summary>


Data type | Description
:--- | :---
<i>CHAR(size)</i> |  A FIXED length string (can contain letters, numbers, and special characters). The size parameter specifies the column length in characters - can be from 0 to 255. Default is 1
<i>VARCHAR(size)</i> | A VARIABLE length string (can contain letters, numbers, and special characters). The size parameter specifies the maximum column length in characters - can be from 0 to 65535
<i>BINARY(size)</i> |  Equal to CHAR(), but stores binary byte strings. The size parameter specifies the column length in bytes. Default is 1
<i>VARBINARY(size)</i> | Equal to VARCHAR(), but stores binary byte strings. The size parameter specifies the maximum column length in bytes.
<i>TINYBLOB</i> |  For BLOBs (Binary Large OBjects). Max length: 255 bytes
<i>TINYTEXT</i> |  Holds a string with a maximum length of 255 characters
<i>TEXT(size)</i> |  Holds a string with a maximum length of 65,535 bytes
<i>BLOB(size)</i> |  For BLOBs (Binary Large OBjects). Holds up to 65,535 bytes of data
<i>MEDIUMTEXT</i> |  Holds a string with a maximum length of 16,777,215 characters
<i>MEDIUMBLOB</i> |  For BLOBs (Binary Large OBjects). Holds up to 16,777,215 bytes of data
<i>LONGTEXT</i> |  Holds a string with a maximum length of 4,294,967,295 characters
<i>LONGBLOB</i> |  For BLOBs (Binary Large OBjects). Holds up to 4,294,967,295 bytes of data
<i>ENUM(val1, val2, val3, ...)</i> | A string object that can have only one value, chosen from a list of possible values. You can list up to 65535 values in an ENUM list. If a value is inserted that is not in the list, a blank value will be inserted. The values are sorted in the order you enter them
<i>SET(val1, val2, val3, ...)</i> |  A string object that can have 0 or more values, chosen from a list of possible values. You can list up to 64 values in a SET list



</details>


<details>
  <summary>Numeric Data Types</summary>


Data type | Description
:--- | :---
<i>BIT(size)</i> | A bit-value type. The number of bits per value is specified in size. The size parameter can hold a value from 1 to 64. The default value for size is 1.
<i>TINYINT(size)</i> | A very small integer. Signed range is from -128 to 127. Unsigned range is from 0 to 255. The size parameter specifies the maximum display width (which is 255)
<i>BOOL</i> |  Zero is considered as false, nonzero values are considered as true.
<i>BOOLEAN</i> | Equal to BOOL
<i>SMALLINT(size)</i> |  A small integer. Signed range is from -32768 to 32767. Unsigned range is from 0 to 65535. The size parameter specifies the maximum display width (which is 255)
<i>MEDIUMINT(size)</i> | A medium integer. Signed range is from -8388608 to 8388607. Unsigned range is from 0 to 16777215. The size parameter specifies the maximum display width (which is 255)
<i>INT(size)</i> | A medium integer. Signed range is from -2147483648 to 2147483647. Unsigned range is from 0 to 4294967295. The size parameter specifies the maximum display width (which is 255)
<i>INTEGER(size)</i> | Equal to INT(size)
<i>BIGINT(size)</i> |  A large integer. Signed range is from -9223372036854775808 to 9223372036854775807. Unsigned range is from 0 to 18446744073709551615. The size parameter specifies the maximum display width (which is 255)
<i>FLOAT(size, d)</i> |  A floating point number. The total number of digits is specified in size. The number of digits after the decimal point is specified in the d parameter. This syntax is deprecated in MySQL 8.0.17, and it will be removed in future MySQL versions
<i>FLOAT(p)</i> |  A floating point number. MySQL uses the p value to determine whether to use FLOAT or DOUBLE for the resulting data type. If p is from 0 to 24, the data type becomes FLOAT(). If p is from 25 to 53, the data type becomes DOUBLE()
<i>DOUBLE(size, d)</i> | A normal-size floating point number. The total number of digits is specified in size. The number of digits after the decimal point is specified in the d parameter
<i>DOUBLE PRECISION(size, d)  </i> |
<i>DECIMAL(size, d)</i> |  An exact fixed-point number. The total number of digits is specified in size. The number of digits after the decimal point is specified in the d parameter. The maximum number for size is 65. The maximum number for d is 30. The default value for size is 10. The default value for d is 0.
<i>DEC(size, d)</i> |  Equal to DECIMAL(size,d)


</details>




<details>
  <summary>Date and Time Data Types</summary>


Data type | Description
:--- | :---
<i>DATE</i> |  A date. Format: YYYY-MM-DD. The supported range is from '1000-01-01' to '9999-12-31'
<i>DATETIME(fsp)</i> | A date and time combination. Format: YYYY-MM-DD hh:mm:ss. The supported range is from '1000-01-01 00:00:00' to '9999-12-31 23:59:59'. Adding DEFAULT and ON UPDATE in the column definition to get automatic initialization and updating to the current date and time
<i>TIMESTAMP(fsp)</i> |  A timestamp. TIMESTAMP values are stored as the number of seconds since the Unix epoch ('1970-01-01 00:00:00' UTC). Format: YYYY-MM-DD hh:mm:ss. The supported range is from '1970-01-01 00:00:01' UTC to '2038-01-09 03:14:07' UTC. Automatic initialization and updating to the current date and time can be specified using DEFAULT CURRENT_TIMESTAMP and ON UPDATE CURRENT_TIMESTAMP in the column definition
<i>TIME(fsp)</i> | A time. Format: hh:mm:ss. The supported range is from '-838:59:59' to '838:59:59'
<i>YEAR</i> |  A year in four-digit format. Values allowed in four-digit format: 1901 to 2155, and <0000 class=""></0000>


</details>

