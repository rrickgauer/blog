## Overview

[Classes](https://docs.python.org/3/tutorial/classes.html) in python are relatively simple to create. However, there is one thing you need to rememeber: every method needs a `self` parameter:

```py
def classMethod(self, parm1, parm2):
    # logic goes here
```

Also, the constructor method is called `__init__`.

## Standard Class

Let's create a python class called `Person`:

```py
class Person:

    # constructor
    def __init__(self, new_first_name, new_last_name):
        self.first_name = new_first_name
        self.last_name = new_last_name

    # set the first_name property
    def setFirstName(self, new_first_name):
        self.first_name = new_first_name
    
    # generate a username
    # first letter of the first name plus the last name
    def getUserName(self):
        user_name = self.first_name[0] + self.last_name

        return user_name
```

### Using the `Person` class

```py
# create a new Person object
person1 = Person('George', 'Clooney')
print(person1.first_name)       # George
print(person1.last_name)        # Clooney
print(person1.getUserName())    # GClooney

# change the first name
person1.setFirstName('Ryan')
print(person1.first_name)       # Ryan
print(person1.last_name)        # Clooney
print(person1.getUserName())    # RClooney

# change the last name
person1.last_name = 'Smith'
print(person1.first_name)       # Ryan
print(person1.last_name)        # Smith
print(person1.getUserName())    # RSmith
```


## Static Methods

[Static methods](https://docs.python.org/3/library/functions.html#staticmethod) are the methods that can be called without creating an object of class. They are referenced by the class name itself or reference to the Object of that class. Be sure to add the `@staticmethod` tag to methods.

Static properties are declared inside the class definition, but not inside a method are class or "static" variables:

```py
class Utilities:
    version_number = 11   # static property

    @staticmethod
    def printList(theList):
        for element in theList:
            print(element)
```

Then in your main logic:

```py
print(Utilities.version_number)   # 11

# print a list 
myList = [4, 10, 50, 100]
Utilities.printList(myList)
# 4
# 10
# 50
# 100
```


## Dunder Methods

In Python, [dunder methods](https://dbader.org/blog/python-dunder-methods) are a set of predefined methods you can use to enrich your classes. They have leading and trailing underscores surrounding their method names.

This tutorial is going to cover a few of these methods, but there are several others you can choose to implement.


### Printing Objects

Using the `Person` class from before, if we create the `__str__` method, we can override what happens when we print the object:

```py
class Person:
    __str__(self):
        output = "Person: {}, {}".format(self.first_name, self.last_name)
        return output
```

Then when we call the `print()` function it prints whatever we returned in the `__str__` method:

```py
person2 = Person('George', 'Washington')

print(person2)    # 'Person: Washington, George'
```

### Comparing Objects

Built in python types are easy to compare:

```py
print(2 > 1)              # True
print('Hello' == 'bye')   # False
```

We can implement the `__eq__` and `__lt__` dunder methods to compare objects. This is called [operator overloading](https://en.cppreference.com/w/cpp/language/operators) in C++.

To not have to implement all of the comparison dunder methods, I use the `functools.total_ordering` decorator which allows me to take a shortcut, only implementing `__eq__` and `__lt__`:

```py
from functools import total_ordering

@total_ordering
class BankAccount:
    # constructor
    def __init__(self, balance):
        self.balance = balance
    
    # equal to operator overloading
    def __eq__(self, other):
        return self.balance == other.balance

    # less than operator overloading
    def __lt__(self, other):
        return self.balance < other.balance
```


This is how we would use these

```py
bankAccount1 = BankAccount(100)
bankAccount2 = BankAccount(500000)
bankAccount3 = BankAccount(100)

print(bankAccount1 == bankAccount2)     # False
print(bankAccount1 < bankAccount2)      # True
print(bankAccount3 == bankAccount1)     # True
print(bankAccount2 > bankAccount3)      # True
print(bankAccount1 > bankAccount3)      # False
```

