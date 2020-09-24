## Table of Contents

<details closed>
<summary>Click to expand</summary>


1. [Opening a file](#opening-a-file)
1. [Closing a file](#closing-a-file)
1. [Reading a file](#reading-a-file)
1. [Writing to a file](#writing-to-a-file)


</details>

## Opening a file

[File operations](https://docs.python.org/3/tutorial/inputoutput.html#reading-and-writing-files) usually start with creating a file object.

```py
f = open(fileName, mode)
```

* `fileName` is a string such as *names.txt*
* `mode` must be one of the accepted file modes:

Mode | Description
:--- | :---
`r` | Opens a file for reading. (default)
`w` | Opens a file for writing. Creates a new file if it does not exist or truncates the file if it exists.
`x` | Opens a file for exclusive creation. If the file already exists, the operation fails.
`a` | Opens a file for appending at the end of the file without truncating it. Creates a new file if it does not exist.
`t` | Opens in text mode. (default)
`b` | Opens in binary mode.
`+` | Opens a file for updating (reading and writing)

### Examples

```py
f = open("test.txt")      # equivalent to 'r' or 'rt'
f = open("test.txt",'w')  # write in text mode
```

## Closing a file

When you are done using the file, you should close it via:

```py
f.close()
```

You can also use python's `with` function so you don't need to close the file:

```py
with open('test.txt', 'w') as f:
  # file operations
```

## Reading a file

To read the contents of a file line by line by using a *for loop*:

```py
with open('test.txt', 'w') as f:
  for line in f:
    print(line)
```

Or you can use the `readLine()` file method:

```py
print(f.readline())       # "This is my first file\n"
print(f.readline())       # "This file\n"
print(f.readline())       # "contains three lines\n"
```

## Writing to a file

To write to a file, use the `write()` method.

```py
f.write("this is line one \n")
f.write("this is line two \n")
f.write("this is line three \n")
```

