Creating classes in PHP is pretty straightforward. The [official docs](https://www.php.net/manual/en/language.oop5.php) have some great examples.


<details>
<summary>Table of Content</summary>


1. [Simple Classes](#simple-classes)
1. [Static Methods](#static-methods)
1. [Inheritance](#inheritance)


</details>


## Simple Classes

Here is an example of a simple class named `Person`:

```php

class Person {

  private $firstName;
  private $lastName;
  private $ssn;

  public function __construct($newFirstName, $newLastName, $newSSN) {
    $this->setFirstName($newFirstName);
    $this->setLastName($newLastName);
    $this->setSSN($newSSN);
  }

  // Getters
  public function getFirstName() {
    return $this->firstName;
  }

  public function getLastName() {
    return $this->lastName;
  }

  public function getSSN() {
    return $this->ssn;
  }

  // Setters
  public function setFirstName($newFirstName) {
    $this->firstName = $newFirstName;
  }

  public function setLastName($newLastName) {
    $this->lastName = $newLastName;
  }

  public function setSSN($newSSN) {
    $this->ssn = $newSSN;
  }
}
```

You can use the `Person` class anywhere in your files as long as you include the file name at the top of your page:

```php

include_once('Person-Class.php');

$person1 = new Person('Ryan', 'Rickgauer', 111111111);
$person2 = new Person('Bill', 'Gates', 123456788);

echo $person1->getFirstName();      // Ryan
echo $person2->getLastName();       // Gates

$person1->setFirstName('Jimbo');
echo $person1->getFirstName();      // Jimbo
```


## Static Methods

Declaring class methods as [static](https://www.php.net/manual/en/language.oop5.static.php) makes them accessible without needing an instantiation of the class. In other words, to call a static method, you don't need to create an object of that class in order to do so.

Below is an example of using some static methods in a class called `MyStaticClass`:

```php

class MyStaticClass {

  public static function getSum($num1, $num2) {
    return $num1 + $num2;
  }

  public static function printSum($num1, $num2) {
    // Call the getSum static method to retrieve the sum
    $sum = MyStaticClass::getSum($num1, $num2);

    // Generate the output
    $output = $num1 . ' + ' . $num2 . ' = ' . $sum;

    // Print the output
    echo $output;
  }
}


$sum1 = MyStaticClass::getSum(20, 20);    // $sum1 = 40

MyStaticClass::printSum($sum1, 60);       // 40 + 60 = 100 
```

## Inheritance

[Inheritance](https://www.php.net/manual/en/language.oop5.inheritance.php) is a well-established programming principle, and PHP makes use of this principle in its object model. This principle will affect the way many classes and objects relate to one another. For example, when you extend a class, the subclass inherits all of the public and protected methods from the parent class. Unless a class overrides those methods, they will retain their original functionality. This is useful for defining and abstracting functionality, and permits the implementation of additional functionality in similar objects without the need to reimplement all of the shared functionality.


#### Visibility

Before we look at an example, let's talk about [visibility](https://www.php.net/manual/en/language.oop5.visibility.php). There are 3 types of visibility in php:

1. `public` &mdash; members can be accessed anywhere by anyone
1. `protected` &mdash; members can be accessed only within the class itself and by inheriting and parent classes
1. `private` &mdash; members can be only be accessed by the class that defines the member


Now, let's take a look at an example of inheritance in php:

```php

class Base {

  // these properties will be accessible by the child class
  protected $firstName;
  protected $lastName;

  // not accessible by the child class or anyone else
  private $noAccess;

  public function __construct($newFirstName, $newLastName) {
    $this->firstName = $newFirstName;
    $this->lastName = $newLastName;
  }

  // accessible by anyone
  public function getFirstName() {
    return $this->firstName;
  }

  // accessible by anyone
  public function getLastName() {
    return $this->lastName;
  }

  // accessible by anyone
  public function getNoAccess() {
    return $this->noAccess;
  }

  // accessible by only the child class
  protected function setFirstName($newFirstName) {
    $this->firstName = $newFirstName;
  }

  // accessible by only the child class
  protected function setLastName($newLastName) {
    $this->lastName = $newLastName;
  }
}

```


Now, let's build a `Child` class that *inherits* the `Base` class:


```php

class Child extends Base {

  private $middleName;

  public __construct($newFirstName, $newLastName, $newMiddleName) {
    // call the parent's contruction function
    // to set the first and last name
    parent::__construct($newFirstName, $newLastName);

    $this->middleName = $newMiddleName;
  }

  public function getMiddleName() {
    return $this->middleName;
  }

  // Override the base function
  private function setFirstName($newFirstName) {
    $this->firstName = 'Poopy';
  }
}
```


Let's now implement these 2 classes:

```php
$base = new Base('Ryan', 'Rickgauer');
echo $base->getFirstName();                       // Ryan
echo $base->getLastName();                        // Rickgauer

// change the first name
$base->setFirstName('Jimmy');
echo $base->getFirstName();                       // Jimmy


$child = new Child('Tyler', 'Obama', 'Thomas');
echo $child->getFirstName();                      // Tyler
echo $child->getLastName()                        // Obama
echo $child->getMiddleName()                      // Thomas


// use the child's setFirstName()
$child->setFirstName('Conan');
echo $child->getFirstName();                      // Poopy
```

