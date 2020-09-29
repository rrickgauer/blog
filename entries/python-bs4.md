[Beautiful Soup](https://www.crummy.com/software/BeautifulSoup/bs4/doc/) is a Python library for pulling data out of HTML and XML files. It's one of the most popular python modules and is pretty easy to use.

## Table of Contents


<details>
<summary>Click me to open</summary>


1. [Installation](#installation)
1. [Usage](#usage)
    1. [Searching for elements](#searching-for-elements)


</details>

## Installation

To install Beautiful Soup 4 (BS4), you can just use [pip](https://github.com/pypa/pip):

```sh
pip install beautifulsoup4
```

In this post, I am going to use the [requests](https://github.com/psf/requests) python library:

```sh
pip install requests
```

Before we get started, be sure to include the modules in your python script:

```py
import requests
from bs4 import BeautifulSoup
```

## Usage

The first step is to retrieve the html from the website. 

```py
response = requests.get('http://example.com/')
soup = BeautifulSoup(response.text, 'html.parser')
```

`soup` contains the BS4 object that you can parse.

There are a few different parsers: html.parse, [lxml](https://lxml.de/), [lxml-xml](https://lxml.de/), and [html5lib](https://github.com/html5lib/html5lib-python). Each has its own [advantages and disadvantages](https://www.crummy.com/software/BeautifulSoup/bs4/doc/#installing-a-parser). 


### Searching for elements

To find an element with a specific id:

```py
element = soup.find(id='elementTagID')
```

One common task is extracting all the URLs found within a page’s `<a>` tags:

```py
for link in soup.find_all('a'):
  print(link.get('href'))

# http://example.com/elsie
# http://example.com/lacie
# http://example.com/tillie
```

To get the link text from the page you can do 

```py
for link in soup.find_all('a'):
  print(link.get_text())

# Click here
# another link text
# IDK what else to put
```

To get all link elements with the CSS class `sister`:

```python
soup.find_all("a", class_="sister"):
```