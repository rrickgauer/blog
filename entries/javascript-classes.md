[Classes](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes) in JavaScript are a little different than other languages. There are a few different ways to make a class. 

Let's make a new class called `Person`


```js
// Constructor
function Person(firstName, lastName) {
  this.firstName = firstName;
  this.lastName = lastName;
}

Person.prototype.setFirstName = function(newFirstName) {
  this.firstName = newFirstName;
}

Person.prototype.setLastName = function(newLastName) {
  this.lastName = newLastName;
}

Person.prototype.getUsername = function() {  
  const firstLetter = this.firstName[0];          // get first letter of the first name
  const username = firstLetter + this.lastName;   // combine first letter with the last name
  return username.toLowerCase();
}
```


To instantiate a `Person` object:

```js
const person1 = new Person('Ryan', 'Rickgauer');

console.log(person1.firstName);           // Ryan
console.log(person1.lastName);            // Rickgauer
console.log(person1.getUsername());       // rrickgauer

// Change up some shit
person1.setFirstName('James');
person1.lastName = 'Harden';

console.log(person1.firstName);           // James
console.log(person1.lastName);            // Harden
console.log(person1.getUsername());       // jharden
```

## Additional Notes

### `this` Keyword

Use `this` to access the properties of a class.

```js
this.dataMember;
this.method();
```

#### Remeber your scope

However, sometimes when you are using [higher-order functions](https://eloquentjavascript.net/05_higher_order.html), the scope of `this` is changed. For instance,

```js
function MyClass(number) {
  this.number = number;
}


MyClass.prototype.setHtmlInputValue = function() {
  // set a variable to self before you go into a higher-order function
  const sef = this;
  
  $('button').on('click', function() {
    // will not work since I am within a higher-order function
    let x = this.number;

    // works
    let x2 = self.number
  });
}
```

The first assignment to `x` does not work, because `this` is refering to the button element. That's why I made a variable called `self` and set it to `this` outside of the higher-order function.


### Method parameters

If you have a class that has some parameters for its constructor, you don't have to pass in arguments when you create an object. You can check if the parameter is `undefined`:

```js
function Dog(weight, breed) {
  
  if (weight == undefined)
    this.weight = null;
  else
    this.weight = weight;

  
  if (breed == undefined)
    this.breed = null;
  else
    this.breed = breed;
}


let dog1 = new Dog(60, 'pitbull');
console.log(dog1.weight);               // 60
console.log(dog1.breed);                // pitbull

let dog2 = new Dog();
console.log(dog2.weight);               // null
console.log(dog2.breed);                // null

let dog3 = new Dog(150);
console.log(dog3.weight);               // 150
console.log(dog3.breed);                // null
```


