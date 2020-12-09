This is a cheatsheet I made that covers some basic markdown syntax. I got most of the content from the [Markdown cheatsheet](https://devhints.io/markdown) by [devhints.io](https://devhints.io/).



### Headers

```md
# h1
## h2
### h3
#### h4
##### h5
###### h6

Header 1
========


Header 2
--------
```

### Code

```md
    4 space indent
    makes a code block
```


```md

  ```
  code fences
  ```

```





    ```js
    codeFences.withLanguage()
    ```


### Tables


```md
| Column 1 Heading | Column 2 Heading |
| ---------------- | ---------------- |
| Some content     | Other content    |


Column 1 Heading | Column 2 Heading
--- | ---
Some content | Other content
```



### Emphasis


```md
*italic*
_italic_

**bold**
__bold__

`code`

~~Strikethrough~~

Subscript~example~
Superscript^example^
```


### Links

```md
[link](http://google.com)

[link][google]
[google]: http://google.com

<http://google.com>
```


### Blockquotes


```md
> This is
> a blockquote
>
> > Nested
> > Blockquote
```

### Lists

```md
* Item 1
* Item 2
  * sub item 1
  * sub item 2

- Item 1
- Item 2
  - sub item 1
  - sub item 2

- [ ] Checkbox off
- [x] Checkbox on

1. Item 1
2. Item 2
```



### Images

```md
![Image alt text](/path/to/img.jpg)
![Image alt text](/path/to/img.jpg "title")
![Image alt text][img]

[img]: http://foo.com/img.jpg
```

### Horizontal line


```md
----

****
```


