[Classes](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes) in JavaScript are a little different than other languages. There are a few different ways to make a class. 

## Basics

Let's make a new class called `Person`


```js
export class Person
{
    constructor(firstName, lastName, age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    getUserName = () =>
    {
        const username = `${this.firstName[0]}${this.lastName}`;
        return username;
    }

    canDriveCar = () => this.age >= Person.DRIVING_AGE_LIMIT;
}

Person.DRIVING_AGE_LIMIT = 16;
```


Now, let's use this class.


```js
import { Person } from "./person.js";

const ryan = new Person('Ryan', 'Rickgauer', 26);
const james = new Person('James', 'Bond', 55);
const bruce = new Person('Bruce', 'Wayne', 11);

printPerson(ryan);      // "Rickgauer, Ryan - RRickgauer - true"
printPerson(james);     // "Bond, James - JBond - true"
printPerson(bruce);     // "Wayne, Bruce - BWayne - false"

function printPerson(person) {
    const output = `${person.lastName}, ${person.firstName} - ${person.getUserName()} - ${person.canDriveCar()}`;
    console.log(output);
}
```




## Static methods and properties

[MDN Docs](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes#static_methods_and_properties)

### Static Methods

To mark a method as static, just prefix the method name with `static`:

```js
export class Utilities
{
    static sum = (num1, num2) =>
    {
        return num1 + num2;
    }
}
```

To use this:

```js
import { Utilities } from "./utilities.js";

const result = Utilities.sum(5, 10); // 15
```


### Static Properties

To create a static property:

```js
export class Utilities
{
    static sum = (num1, num2) =>
    {
        return num1 + num2;
    }
}

Utilities.MAX_DB_CONNECTIONS = 100;
```

To use this:

```js
import { Utilities } from "./utilities.js";

console.log(Utilities.MAX_DB_CONNECTIONS);
```


## Inheritance

https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Objects/Classes_in_JavaScript#inheritance

We use the `extends` keyword to say that a class inherits from another class.

Let's make a sub-class `Student` that inherits from the `Person` class we created earlier.

```js
export class Person
{
    constructor(firstName, lastName, age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    getUserName = () =>
    {
        const username = `${this.firstName[0]}${this.lastName}`;
        return username;
    }

    canDriveCar = () => this.age >= Person.DRIVING_AGE_LIMIT;
}

Person.DRIVING_AGE_LIMIT = 16;
```

Now, let's make the student sub-class:

```js
import { Person } from "./person.js";

export class Student extends Person
{
    constructor(firstName, lastName, age, grade)
    {
        super(firstName, lastName, age);
        this.grade = grade;
    }

    // checks if student is in middle school
    isInMiddleSchool = () =>
    {
        if (Student.MIDDLE_SCHOOL_GRADES.includes(this.grade))
        {
            return true;
        }

        return false;
    }
}

Student.MIDDLE_SCHOOL_GRADES = [6, 7, 8];
```

To use the `Student` class:


```js
import { Student } from "./student.js";

const ryanStudent = new Student('Ryan', 'Rickgauer', 26, 5);
const jamesStudent = new Student('James', 'Bond', 55, 11);
const bruceStudent = new Student('Bruce', 'Wayne', 11, 8);

console.log(ryanStudent.isInMiddleSchool())     // false
console.log(jamesStudent.isInMiddleSchool())    // false
console.log(bruceStudent.isInMiddleSchool())    // true

// inherited from the Person class
console.log(ryanStudent.getUserName());     // RRickgauer
console.log(jamesStudent.getUserName());    // JBond
console.log(bruceStudent.getUserName());    // BWayne
```
