# Personal Python Library

This is my personal python utilities library that I made so that I can quickly access it from anywhere if needed. This is a work in progress so I will be updating as the time comes. The repo can be found [here](https://github.com/rrickgauer/python-utilities).

## Functions
### Space
This function basically just prints out a specified number of new lines.

```python
def space(numSpaces = 1):
    for x in range(numSpaces):
        print('')
```

### Beautiful Table

[Beautiful Table](https://github.com/pri22296/beautifultable) is a module I just discovered the other day. It has come in quite handy, and I highly recommend to anyone that needs an easy way to print out tables in the terminal.

#### Installation

```shell
pip install beautifultable
```

#### Usage
```python
from beautifultable import BeautifulTable

def getTable(data, columns=[]):
    table = BeautifulTable(max_width=1000)
    table.set_style(BeautifulTable.STYLE_COMPACT)

    if len(columns) > 0:
        table.column_headers=columns

    for row in data:
        table.append_row(row)

    table.column_alignments = BeautifulTable.ALIGN_LEFT
    return table
```
