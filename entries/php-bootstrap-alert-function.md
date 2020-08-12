Many times, I have had to create a [bootstrap alert](https://getbootstrap.com/docs/4.5/components/alerts/) in my web applications. So many in fact, I started writing a php function that can create it for me. Here is my snippet.

This is the function you can use throughout your code:

```php
// returns a bootstrap alert
function getAlert($message, $alertType = 'success') {
  return "
  <div class=\"alert alert-$alertType alert-dismissible mt-5 mb-5 fade show\" role=\"alert\">
    $message
    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">
      <span aria-hidden=\"true\">&times;</span>
    </button>
  </div>";
}
```

Then, whenever you need an alert, you can use it by doing this:

```php
echo getAlert('Your message goes here', 'warning');
```

## Parameters

The ```$alertType``` defaults to *success*, but bootstrap offers [several different options](https://getbootstrap.com/docs/4.5/components/alerts/#examples) for the type of alert you have.


![Image](https://www.jquery-az.com/wp-content/uploads/2018/01/20-1-Bootstrap-4-alerts.png)

## Further Reading

My [Bootstrap Notes post](https://www.ryanrickgauer.com/blog/entries.php?entryID=11) contains several of my favorite bootstrap code snippets. Check it out!