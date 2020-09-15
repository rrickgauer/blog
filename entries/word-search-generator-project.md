# Word Search Generator Project
Recently, I purchased a subscription to the [Chicago Tribune](https://www.chicagotribune.com/), and while reading over the first issue I received, I noticed that they included a word search. As the days went on, I really started to enjoy working through the puzzle. 

This got me thinking about how the publishers generated the puzzle. So I decided to see if I could make my own. As a result, I am pleased to share my own [word search puzzle generator](https://ryanrickgauer.com/word-search/index.html)! Here is a link to the [GitHub repo](https://github.com/rrickgauer/word-search-generator). 

The premise behind the program is simple: have users enter in a list of words, then generate a word search puzzle.

<p align="center">
  <img src="https://i0.wp.com/ahhc-1.com/blog/wp-content/uploads/2020/02/coronavirus-word-search-puzzle-featured.png?fit=350%2C182&ssl=1">
</p>

## Generating the puzzle

To generate my puzzle, I had to setup a few things.


### List of words

After the user enters the list of words they would like to use, the program sorts the words longest to shortest.

### Directions

Words in a puzzle can have 8 *directions*:

Direction | Visual
--- | ---
up | &uarr;
down | &darr;
left | &larr;
right | &rarr;
up-left | &nwarr;
up-right | &nearr;
down-left | &swarr;
down-right | &searr;


### Puzzle Grid

Every time a puzzle is generated, you need to setup the initial puzzle grid. 

To do this, I created a 2-d array and set every point in there to a `NULL` value.

#### Grid Points

My programs implements a `Point` class that represents a (X, Y) point on the puzzle grid.

### Algorithm

Once the directions are set and the words are sorted, it is time to generate the puzzle.

The algorithm was pretty simple, for each word in the puzzle:

1. Assign a random direction to the word
2. Assign a random starting point to the word
3. Check if the word can be inserted into the grid with its direction and starting point
    * if Yes, insert the word into the grid
    * if No, go back to step 1

### How to check if word can be inserted

To check if the word can be inserted into the puzzle, there are a few things you need to examine. You will need the word itself, the starting point, and the direction.

The word *cannot* be inserted if any of the conditions are true:

* If the word length exceeds the grid dimensions
  * The grid is 4 x 4 size and the word is "COLLEGE".
* If the word "falls off" the grid due to the direction and number of points
  * For example, say the grid is a 10 x 10 size, the word is "CHICAGO", the starting point is (9, 10), and the direction is down.
    * After the first letter ("C") is placed, the next point would be (9, <span style="color: red;"><b>11</b></span>) which does not exist in the grid
* If you reach a point in the grid that already has a letter placed in it, that does not equal the letter in the word to be placed

## Further reading

https://github.com/sbj42/word-search-generator

https://github.com/jamis/wordsearch

https://github.com/danbarbarito/Word-Search-Generator

https://weblog.jamisbuck.org/2015/9/26/generating-word-search-puzzles.html