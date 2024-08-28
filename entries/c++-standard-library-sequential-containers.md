
## Storing Sequences of Elements with Vectors

To use vectors in an application:
```c++
#include <vector>
```

### Initialization

To initialize an empty vector:
```c++
vector<float> temperatures{};   // empty vector

```

To initialize a vector with values in it:
```c++
vector<int> v{5, 6, 10, 23};    // initial values
```

Create a vector containing *count* copies of a given element:
```c++
vector<string> v{3, "Connie"};  // 3 copies of 'Connie'
```

### Inserting elements

To insert a new element into a vector:
```c++
temperatures.push_back(element);
```

### Other common methods

To get the number of elements:
```c++
vector.size();  // returns the number of elements
```

To check if vector has no elements:
```c++
if (v.empty()) {
  cout << "Vector is empty.";
}
```

To erase all elements from the vector:
```c++
v.clear();
```

### Accessing elements

To access elements in an array, you can use bracket notation, just like an array:
```c++
v[i];
```

Or, you can use the ```.at()``` method:

```c++
v.at(i);
```

### Method table

| Method | Description |
| ------ | --- |
| v.push_back(element) | insert an element into the vector | 
| v.size() | Returns the size of the vector | 
| v.empty() | Returns true/false if vector has no elements |
| v.clear() | Removes all elements in the vector | 

## Useful Standard Algorithms: Sorting Vectors

You can use the standard library's ```sort()``` function to sort elements in a container. To use the ```sort()``` algorithm, you must include it in the application:
```c++
#include <algorithm>
```

The ```sort()``` algorithm can be used in many ways. However, a common way to use it requires 2 input parameters:

```c++
sort(firstElement, lastElement);
sort(begin(v), end(v));             // v is a std::vector
```

### Sorting using custom comparison

Custom sorting of a ```vector<string>``` using a *lambda*:
```c++
// 'names' is a vector<string>
sort(begin(names), end(names)),
  [](auto const& a, auto const& b) {
    return a.length() < b.length();       // compare by string length
  }
```

## Inserting, Removing, and Searching Elements

### Inserting elements

Use the ```insert()``` function to insert an element into a vector in a specified position.
```c++
v.insert(position, value);
```

The *position* parameter needs to be an iterator type. For example, to insert an element into the 3rd position in a vector you can do as follows:
```c++
v.insert(begin(v) + 2, 64);
```

### Removing elements

You can remove elements in a vector by using the ```remove()``` function. Here, all elements that are equal to a given *value* are removed. The syntax is as follows:

```c++
remove(firstElement, lastElement, value);
```

You can remove elements in a vector by using the ```remove_if()``` function. Here, all elements are removed for which a *predicate* is *true*. The syntax is as follows:
```c++
remove_if(firstElement, lastElement, predicate);
```

* **Note:** you should call the ```erase()``` method on the vector after the ```remove()``` ```remove_if()``` function is called to remove the garbage located at the end of the vector.

* [Official docs](https://en.cppreference.com/w/cpp/algorithm/remove)

### Searching elements

Use ```find()``` to search for elements in a container. The basic syntax is as follows:
```c++
iterator = find(firstElement, lastElement, value);
```

Additionally, you can use the ```find_if()``` function to do a conditional search:
```c++
iterator = find_if(firstElement, lastElement, predicate);
```

#### Example

One use case for using ```find_if()``` over ```find()``` is when you want to do a case-insensitive string search. This is because the value parameter in```find()```is case sensitive.
```c++
vector<string> v{"Ryan", "Michael", "Connie", "C++"};

auto it1 = find(begin(v), end(v), "Connie");                  // returns iterator to 'Connie'
auto it2 = find(begin(v), end(v), "CONNIE");                  // would not find 'CONNIE'
auto it3 = find_if(begin(v), end(v), caseInsensitiveCompare); // would find 'Connie', 'CONNIE', 'connie', etc...
```

## Safely Encapsulating Fixed-size Arrays

* [Official docs](http://www.cplusplus.com/reference/array/array/)

C++ offers a fixed sized container called ```std::array```. 
> It is as efficient in terms of storage size as an ordinary array declared with the language's bracket syntax ([]). This class merely adds a layer of member and global functions to it, so that arrays can be used as standard containers.

### Common operations

#### Construction

To construct a ```std::array``` you can do either of the following:
```c++
array<int, 3> a = {11, 22, 33};
array<int, 3> a{11, 22, 33};
```

#### Size

Use ```std::array::size``` to return the number of elements in the container:
```c++
array<double, 4> a = {10.0, 20.0, 50.0, 40.0};
cout << "Number of elements: << a.size();       // prints out 4
```

#### Element access

To access elements in a ```std::array``` you can use bracket notation or the ```at()``` method:
```c++
array <int, 4> a = {5, 20, 3, 9};

cout << a[1];     // 20
cout << a.at(3);  // 9 
```

#### Assignment

Unlike built in raw arrays, ```std::array``` does support assignment
```c++
array<int, 3> a1 = {10, 20, 30};
array<int, 3> a2 = {51, 61, 71};

a2 = a1;  // works fine
```

## Linked Lists

* [Official docs](http://www.cplusplus.com/reference/list/list/)

C++ offers a linked list container through ```std::list```. Be sure to include the list library in your application via ```#include <list>```.

A linked list is a linear sequence of nodes, or a chain of nodes. Usually, linked lists are implemented as a *doubly-linked list*. Because of this, doubly linked lists can provide iterators that can be moved in both directons (forward and backward). These are called *bidirectional iterators*. Furthermore, they allow for element insertion and removal *anywhere*.

#### Construction

To create a ```std::list``` container, you can do any of the following:
```c++
// initialize list with given values
list<int> l{11, 22, 33, 44, 55, 66};

// initialzie an empty list
list<int> l{};
list<int> l;
```

### Common operations

| Method | Description |
| ------ | --- |
| ```size()``` | returns the number of elements in the list |
| ```clear()``` | removes all elements in the list |
| ```empty()``` | returns true if there are 0 elements in the list |

### Inserting/Removing Elements
#### Insertion

To insert elements at the **front** of the list, use the ```list::push_front``` method:
```c++
list<int> l {5, 10, 20};
l.push_front(100);          // l now is {100, 5, 10, 20}
```

To insert elements at the **end** of the list, use the ```list::push_back``` method:
```c++
list<int> l {5, 10, 20};
l.push_back(100);          // l now is {5, 10, 20, 100}
```

To insert an element at a **specific location** use ```list::insert```:
```c++
myList.insert(positionIterator, value);
```

#### Removal

To remove the **front** element, use ```list::pop_front```:
```c++
list<int> l {5, 10, 20};
l.pop_front();              // l now is {10, 20}
```

To remove the **end** element, use ```list::pop_back```:
```c++
list<int> l {5, 10, 20};
l.pop_back();              // l now is {5, 10}
```

To remove **all** elements that are *equal to a value*, use ```list::remove```:
```c++
myList.remove(value);
```

To remove **all** elements that are equal *satisfy a condition*,  use ```list::remove_if```:
```c++
myList.remove_if(condition);
```

### Accessing Elements

The ```std::list``` does *not* allow for bracket notation (myList[3]). Therefore, you must use iterators for element access.

For example, if you wanted to access the fourth element in a list, you could use the ```list::begin``` and ```std::advance``` helpers like so:
```c++
auto it = myList.begin();             // iterator to the begginning of the list
auto fourthElement = advance(it, 3);  // iterator pointing to the 4th element
```









