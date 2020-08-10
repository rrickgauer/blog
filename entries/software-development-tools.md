This is a list of my favorite software tools I use when developing applications.

## Text Editors & IDEs:

### Sublime Text

I use [sublime text](https://www.sublimetext.com/) for several different languages. All my web development is written with sublime: html, css, php, and javascript. Also, I use it to write my python scripts. 

Before sublime, I used to use [Atom](https://atom.io/). However, after using it extensively, it just became too buggy and slow. Sublime opens instantly and has just about the same packages as atom.


### Visual Studio

I use [Visual Studio](https://visualstudio.microsoft.com/) soley for C++. At my current job, that's one of the primary languages I work with so I am constantly using it. 

Before starting my job, I was writing my C++ code with [XCode](https://developer.apple.com/xcode/) on my macbook. Whenever I tried to use Visual Studio on my windows desktop, I couldn't get my programs to compile and run. Since starting my job though, I have come to love visual studio, and would reccommend it to anyone in C++ development.

### Netbeans

I use [Netbeans](https://netbeans.org/) for my Java programs. It's free and I like it's swing form builder. The other popular option is [Eclipse](https://www.eclipse.org/downloads/packages/release/kepler/sr1/eclipse-ide-java-developers).

## Command Line Interface

When I am writing code on my windows desktop, I use [terminus](https://eugeny.github.io/terminus/) for the command line instead of using the default CMD. It is open source, you can modify its apearance and have multiple tabs open at once. 


## SQL Tools

### SQL Formatter

When writing SQL queries, I like to use [SQL Formatter](http://www.dpriver.com/pp/sqlformat.htm) to format the layout of my text. For example, it can take this one line query:

```sql
select Songs.id, Songs.title, Artists.name from Songs left join Artists on Songs.artist_id = Artists.id where Songs.id > 100 order by Songs.title desc limit 20;
```

and turn it into:

```sql
SELECT Songs.id,
       Songs.title,
       Artists.name
FROM   Songs
       LEFT JOIN Artists
              ON Songs.artist_id = Artists.id
WHERE  Songs.id > 100
ORDER  BY Songs.name DESC
LIMIT  20;
```

### Mockaroo

[Mockaroo](https://mockaroo.com/) is a realistic data generator. I use it to populate my database tables whenever with mock data whenever I am doing web development. It's free and really simple to use. 

## Other tools

### Noteable

[Noteable](https://notable.app/) is a free note taking app where you can write your notes in markdown. I use it for all my notetaking for work and I used it when I was in school. You can paste screen shots, enter in math equations, and so much more. I HIGHLY recommend this.

### Backlog

[Backlog](http://www.backlog.cloud/) is a free, open source todo list app. It's really quick and fast, and if you are looking for a simple todo list app I recommend this. 
