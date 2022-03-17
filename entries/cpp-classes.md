
The purpose of this post is to review some basic C++ class concepts.

## Basic Classes

This example will create a class named `Person` that will check if someone is old enough to drive.

The class *declaration* will go into `Person.h`:

```cpp
#pragma once

#include <string>

class Person
{
public:
    // symbolic constants
    static const short MINIMUM_DRIVER_AGE = 16;

    // typedef for common argument types that are prefixed with const and are references
    typedef const std::string& argstring;
    typedef const short& argshort;

    // Constructor with initializer list
    Person(argstring nameFirst, argstring nameLast, argshort age) : nameFirst(nameFirst), nameLast(nameLast), age(age) {};

    bool ableToDrive();

    // Getters
    std::string getNameFirst() const;
    std::string getNameLast() const;
    short getAge() const;

private:
    std::string nameFirst;
    std::string nameLast;
    short age;
};


```

Then, the class *definition* will go into `Person.cpp`:

```cpp
#include "Person.h"

/// <summary>
/// Checks if person is able to drive a car (is age >= 16)
/// </summary>
/// <returns></returns>
bool Person::ableToDrive()
{
    return age < Person::MINIMUM_DRIVER_AGE;
}

/// <summary>
/// Return the object's nameFirst value
/// </summary>
/// <returns></returns>
std::string Person::getNameFirst() const
{
    return nameFirst;
}

/// <summary>
/// Return the object's nameLast value
/// </summary>
/// <returns></returns>
std::string Person::getNameLast() const
{
    return nameLast;
}

/// <summary>
/// Return the object's age value
/// </summary>
/// <returns></returns>
short Person::getAge() const
{
    return age;
}

```


To use the person class:

```cpp
#include <iostream>

#include "Person.h"

int main()
{
    Person person1 = Person("Ryan", "Rickgauer", 26);
    bool personCanDrive = person1.ableToDrive();        // true

    Person person2 = Person("Tony", "Soprano", 12);
    personCanDrive = person2.ableToDrive();             // false
}
```


## Inheritance 


C++ supports inheritance. This example will make a base class called `Vehicle`, and 2 additional classes that inherit from the base class.


```cpp
#include <iostream>
#include <string>

// Base vehicle class
class Vehicle
{

public:
    void printMake() {
        std::cout << make << std::endl;
    }

protected:
    std::string make;
};

```


Now, let's make 2 child classes that inherit from the `Vehicle` class:

```cpp
// Inherits from the vehicle class
class Ford : public Vehicle
{
public:
    Ford() {
        make = "Ford";
    }
};


```

And here is another child class:

```cpp
// Inherits from the vehicle class
class Honda : public Vehicle
{
public:
    Honda() {
        make = "Honda";
    }
};

```

Now, let's see how to create these classes:

```cpp
// main logic
int main()
{
    Ford ford = Ford();
    ford.printMake();           // "Ford"

    Honda honda = Honda();
    honda.printMake();          // "Honda"
}
```
