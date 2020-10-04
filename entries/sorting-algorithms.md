
## Table Of Content

<details>
<summary>Click to open</summary>


1. [Bubble sort](#bubble-sort)
1. [Cocktail sort](#cocktail-sort)
1. [Comb sort](#comb-sort)
1. [Gnome sort](#gnome-sort)
1. [Heap sort](#heap-sort)
1. [Insertion sort](#insertion-sort)
1. [JSort](#jsort)
1. [Jump sort](#jump-sort)
1. [Merge sort](#merge-sort)
1. [Quick sort](#quick-sort)
1. [Quicksort3](#quicksort3)
1. [Selection sort](#selection-sort)
1. [Shaker sort](#shaker-sort)
1. [Shell sort](#shell-sort)
1. [Smooth sort](#smooth-sort)
1. [Snake sort](#snake-sort)


</details>


## Bubble sort

Bubble Sort is a simple sorting algorithm. It works by repeatedly stepping through the list to be sorted, comparing two items at a time and swapping them if they are in the wrong order. The pass through the list is repeated until no swaps are needed, which means the list is sorted.

The algorithm gets its name from the way smaller elements "bubble" to the top (i.e. the beginning) of the list via the swaps. One way to optimize bubblesort (implemented here) is to note that, after each pass, the largest element will always move down to the bottom. Thus it suffices to sort the remaining n - 1 elements each subsequent pass.

Although simple, this algorithm is highly inefficient and is rarely used except in education.


## Cocktail sort

Cocktail sort is a variation of bubble sort that sorts in both directions each pass through the list.

One optimization (implemented here) is to add an if-statement that checks whether there has been a swap after the first pass each iteration. If there hasn't been a swap the list is sorted and the algorithm can stop.


## Comb sort

Comb sort was invented by Stephen Lacey and Richard Box, who first described it to Byte Magazine in 1991. It improves on bubble sort and rivals in speed more complex algorithms like quick sort, The idea is to eliminate turtles, or small values near the end of the list, since in a bubble sort these slow the sorting down tremendously. (Rabbits, large values around the beginning of the list, do not pose a problem in bubble sort.)

In bubble sort, when any two elements are compared, they always have a gap (distance from each other) of one. The basic idea of comb sort is that the gap can be much more than one.

The gap starts out as the length of the list being sorted divided by the shrink factor (generally 1.3; see below), and the list is sorted with that value (rounded down to an integer if needed) for the gap. Then the gap is divided by the shrink factor again, the list is sorted with this new gap, and the process repeats until the gap is one. At this point, comb sort reverts to a true bubble sort, using a gap of one until the list is fully sorted. In this final stage of the sort most turtles have already been dealt with, so a bubble sort will be efficient.

The shrink factor has a great effect on the efficiency of comb sort. In the original article, the authors suggested 1.3 after trying some random lists and finding it to be generally the most effective. A value too small slows the algorithm down because more comparisons must be made, whereas a value too large may not kill enough turtles to be practical.

## Gnome sort

Gnome sort is a sorting algorithm which is similar to insertion sort except that moving an element to its proper place is accomplished by a series of swaps, as in bubble sort. It is conceptually simple, requiring no nested loops. In practice the algorithm has been reported to generally run as fast as Insertion sort, although this depends on the details of the architecture and the implementation

The name comes from the behavior of the Dutch garden gnome in sorting a line of flowerpots. He looks at the flower pot next to him and the previous one; if they are in the right order he steps one pot forward, otherwise he swaps them and steps one pot backwards. If there is no previous pot, he steps forwards; if there is no pot next to him, he is done

Effectively, the algorithm always finds the first place where two adjacent elements are in the wrong order, and swaps them. It takes advantage of the fact that performing a swap can only introduce a new out-of-order adjacent pair right before the two swapped elements, and so checks this position immediately after performing such a swap.


## Heap sort

Heap sort is a much more efficient version of selection sort. Invented by John William Joseph Williams in 1964, it works efficiently by using a data structure called a heap. 

A heap is a specialized tree-based data structure that satisfies the heap property: if B is a child node of A, then key(A) >= key(B). This implies that the element with the greatest key is always in the root node. All elements to be sorted are inserted into a heap, and the heap organizes the elements added to it in such a way that the largest value can be quickly extracted.

Once the data list has been made into a heap, the root node is guaranteed to be the largest element. It is removed and placed at the end of the list, then the heap is rearranged so the largest element remaining moves to the root. Using the heap, finding the next largest element takes much less time than scanning every remaining element, which gives heap sort much better performance than selection sort. Similar to selection sort, the initial conditions have little or no effect on the amount of time required.

Heap sort is one of the best general-purpose sorting algorithms. Although somewhat slower in practice on most machines than a good implementation of quick sort, it has a better worst-case runtime.


## Insertion sort

Insertion sort is a simple comparison sort in which the sorted array (or list) is built one entry at a time. It is much less efficient on large lists than more advanced algorithms such as quicksort, heapsort, or merge sort, but it's very efficient on small (5-50 key) lists, as well as lists that are mostly sorted to begin with.

In abstract terms, every iteration of an insertion sort removes an element from the input data, inserting it at the correct position in the already sorted list, until no elements are left in the input. The choice of which element to remove from the input is arbitrary and can be made using almost any choice algorithm.


## JSort

JSort is a hybrid of heap sort and insertion sort developed by Jason Morrison. It works by running two heap passes to roughly order the array, and then finishes with an insertion sort.

The first heap pass converts the array to a heap, moving the smallest item to the top. The second heap pass works in reverse, moving the largest element to the bottom. These two passes combine to roughly order the array, though much work is still left to the final insertion sort.

Because each heap pass only partially orders the list, the larger the array the more work is left for the final insertion sort pass, which can end up being highly ineffecient. 

For small lists, JSort is extremely efficient, but due to its design it does not scale well.


## Jump sort

Similar to shell sort and comb sort, jump sort employs a gap value that decreases in each successive pass that allows out-of-place elements to be moved very far initially. The underlying framework is based on bubble sort instead of the more efficient insertion sort, but due to the initial ordering in the early passes it ends up being very efficient in practice, though still somewhat slower than either shell sort or comb sort.


## Merge sort

Similar to quick sort, merge sort is a recursive algorithm based on a divide and conquer strategy. First, the sequence to be sorted is split into two halves. Each half is then sorted independently, and the two sorted halves are merged to a sorted sequence. Merge sort takes advantage of the ease of merging together already sorted lists. 

In many implementations, merge sort calls out to an external algorithm -- usually insertion sort -- when it reaches a level of around 10-20 elements. This is not necessary in Visual Basic; in fact such an implementation appears to slow merge sort's overall performance in practice.

Instead, the implementation here uses the purest form of merge sort, where the list is recursively divided into halves until it reaches a list size of two, at which point those two elements are sorted.

Unfortunately, extra memory is required to combine two sorted lists together. The extra memory in this implementation is in the form of a full copy of the initial array. There are various optimizations that can be made to improve on this, but that is left as an exercise for the reader.

Invented in 1945 by [John von Neumann](http://en.wikipedia.org/wiki/John_von_Neumann), merge sort is far and away the fastest stable algorithm.


## Quick sort

Quick sort was originally invented in 1960 by [Charles Antony Richard Hoare](http://en.wikipedia.org/wiki/C._A._R._Hoare). It is a divide and conquer algorithm which relies on a partition operation. 

To partition an array, a pivot element is first randomly selected, and then compared against every other element. All smaller elements are moved before the pivot, and all larger elements are moved after. The lesser and greater sublists are then recursively processed until the entire list is sorted. This can be done efficiently in linear time and in-place.

Quick sort turns out to be the fastest sorting algorithm in practice. However, in the (very rare) worst case quick sort is as slow as bubble sort. There are good sorting algorithms with a better worst case, e.g. heap sort and merge sort, but on the average they are slower than quick sort by a consistent margin.

The implementation here uses [Niklaus Wirth's](http://en.wikipedia.org/wiki/Niklaus_W) variant for selecting the pivot value, which is simply using the middle value. This works particularly well for already sorted lists.

Its speed and modest space usage makes quick sort one of the most popular sorting algorithms, available in many standard libraries.


## Quicksort3

The critical operation in the standard quick sort is choosing a pivot: the element around which the list is partitioned. The simplest pivot selection algorithm is to take the first or the last element of the list as the pivot, causing poor behavior for the case of sorted or nearly-sorted input. [Niklaus Wirth's](http://en.wikipedia.org/wiki/Niklaus_Wirth) variant uses the middle element to prevent these occurrences, degenerating to O(n²) for contrived sequences. 

The median-of-3 pivot selection algorithm takes the median of the first, middle, and last elements of the list; however, even though this performs well on many real-world inputs, it is still possible to contrive a median-of-3 killer list that will cause dramatic slowdown of a quicksort based on this pivot selection technique. Such inputs could potentially be exploited by an aggressor, for example by sending such a list to an Internet server for sorting as a denial of service attack.

The quicksort3 implementation here uses a median-of-3 technique, but instead of using the first, last and middle elements, three elements are chosen at random. This has the advantage of being immune to intentional attacks, though there is still a possibility (however remote) of realizing the worst case scenario.


## Selection sort

Selection sort is a simple sorting algorithm that mimics the way humans instinctively sort. It works by first scanning the entire list to find the smallest element, swapping it into the first position. It then finds the next smallest element, swapping that into the second position, and so on until the list is sorted.

Selection sort is unique compared to almost any other algorithm in that its running time is not affected by the prior ordering of the list; it always performs the same number of operations because of its simple structure. Selection sort also requires only n swaps, which can be very attractive if writes are the most expensive operation.

Unless writes are very expensive, selection sort will usually be outperformed by the more complicated algorithms, though it will always outperform a basic bubble sort, Heap sort is an efficient variation of selection sort that is both very fast and also scales well.


## Shaker sort

Shaker sort is a gap-based bubble sort with a twist. Most gap sorts -- shell sort, comb sort, et al. -- begin with a large gap and gradually shrink it down to one. By the time the gap reaches one, the list should be mostly ordered so the final pass should be efficient.

Like other gap sorts, shaker sort begins with a large gap which gradually shrinks. However, once the gap reaches one, the gap gets expanded again before shrinking back toward one. The expanding and contracting gap sizes constitute the "shaking" part of shaker sort. Each additional expansion is smaller and smaller until it eventually resolves to one, when no further expansion is done. At this point the list is almost certain to be nearly sorted, so the final bubble sort pass is very efficient.


## Shell sort

Shell sort is a variation of insertion sort that was invented by (and takes its name from) [Donald Shell](http://en.wikipedia.org/wiki/Donald_Shell), who published the algorithm in 1959.

Shell sort improves on insertion sort by comparing elements separated by a gap of several positions. This lets an element take "bigger steps" toward its expected position. Multiple passes over the data are taken using insertion sort with smaller and smaller gap sizes. The last step of Shell sort is with a gap size of one -- meaning it is a standard insertion sort -- guaranteeing that the final list is sorted. By then, the list will be almost sorted already, so the final pass is efficient.

The gap sequence is an integral part of the shellsort algorithm. Any increment sequence will work, so long as the last element is 1. Donald Shell originally suggested a gap sequence starting at half the size of the list, dividing by half every iteration until it reached one. While offering significant improvement over a standard insertion sort, it was later found that steps of three improve performance even further. 

In the implementation here, the initial gap size is calculated by an iterative formula x=3x+1, where x starts at 0 and grows until the gap is larger than the list size. Each insertion sort loop begins by dividing the gap by three, thus ensuring a very large starting gap.

A key feature of shell sort is that the elements remain k-sorted even as the gap diminishes. For instance, if a list was 5-sorted and then 3-sorted, the list is now not only 3-sorted, but both 5- and 3-sorted. If this were not true, the algorithm would undo work that it had done in previous iterations, and would not achieve such a low running time.

Although shell sort is inefficient for large data sets, it is one of the fastest algorithms for sorting small numbers of elements (sets with less than 1000 or so elements). Another advantage of this algorithm is that it requires relatively small amounts of memory. It is worth noting that shell sort enjoyed a brief period when it was the fastest sorting algorithm known, only to be eclipsed by quick sort one year later.


## Smooth sort

Smooth sort is a variation of heap sort developed by [Edsger Dijkstra](http://en.wikipedia.org/wiki/Edsger_Dijkstra) in 1981. (Here is a [direct link](http://www.cs.utexas.edu/users/EWD/ewd07xx/EWD796a.PDF) to his original paper in pdf form.)

Smooth sort has a similar average case to heap sort but a much better best case, with a smooth transition between the two. This is where the name comes from. The advantage of smoothsort is that it's faster if the input is already sorted to some degree. 

Due to its complexity, smoothsort is rarely used. 


## Snake sort

An original algorithm, snake sort was invented by me in 2007 while I was writing this program. It is as fast or faster than any other algorithm, including quick sort, and it scales up as well as quick sort excluding memory constraints. It is in the merge sort family, and is unstable, out-of-place, offline, and non-recursive. I call it snake sort due to its similarities to fantasy football snake drafts.

The idea is simple: A random ordering will result in very small contiguous ordered blocks in either direction. Snake sort begins by identifying all those blocks, and then merges them together. Each merge pass will halve the remaining number of blocks, so it very quickly resolves to a sorted state.

It uses quite a bit of memory: a full copy of the original array, plus an index array (to remember the block cutoffs) half the size of the original array.

One key feature is to bounce the array contents back and forth between the original array and the mirror array. The standard merge sort wastes operations by first merging to a mirror array and then copying the result back each step. Snake sort does a similar merge each pass, but then leaves the result in whichever array was merged to. Each subsequent pass merges to the other array, in effect snaking the results back and forth until the list is fully sorted. This means that if the last step leaves the contents in the mirror array, a final pass must be run to copy that back over the original.

The most interesting feature of snake sort is that the more ordered the array is initially, the faster it runs. Because it is in the unique position of knowing when the intial order is descending, it is optimally efficient at transposing such a list to an ordered state.

