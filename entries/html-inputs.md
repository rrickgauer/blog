This is a list of the different types of inputs for html

## Usage

To use an html input, you should enclose it in a form and do the following:

```html
<input type="text">
```

## Types of Inputs

Input | Description
:--- | :---
button | Defines a button-like input.
checkbox | Defines a checkbox, which the user can toggle on or off.
color | 
date | 
datetime-local | 
email | 
file | Defines a file upload box with a browse button.
hidden | Defines a field within a form that is not visible to the user.
image | Defines an image that is clicked to submit a form.
month | 
number | 
password | Displays an obfuscated password entry field.
radio | Defines a circular selection button in a form.
range | 
reset | Defines a button on a form that will return all fields to their default values.
search | 
submit | Defines a button that is clicked to submit a form.
tel | 
text | Defines a text entry field in a form.
time | 
url | 
week | 


## Input attributes


Attribute | Description
:--- | :---
`step` | Specifies the interval between valid values in a number-based input.
`required` | Specifies that the input field is required; disallows form submission and alerts the user if the required field is empty.
`readonly` | Disallows the user from editing the value of the input.
`placeholder` | Specifies placeholder text in a text-based input.
`pattern` | Specifies a regular expression against which to validate the value of the input.
`multiple` | Allows the user to enter multiple values into a file upload or email input.
`min` | Specifies a minimum value for number and date input fields.
`max` | Specifies a maximum value for number and date input fields.
`list` | Specifies the id of a `<datalist>` element which provides a list of autocomplete suggestions for the input field.
`height` | Specifies the height of an image input.
`formtarget` | Specifies the browsing context in which to open the response from the server after form submission. For use only on input types of "submit" or "image".
`formmethod` | Specifies the HTTP method (GET or POST) to be used when the form data is submitted to the server. Only for use on input types of "submit" or "image".
`formenctype` | Specifies how form data should be submitted to the server. Only for use on input types "submit" and "image".
`formaction` | Specifies the URL for form submission. Can only be used for type="submit" and type="image".
`form` | Specifies a form to which the input field belongs.
`autofocus` | Specifies that the input field should be in focus immediately upon page load.
`accesskey` | Defines a keyboard shortcut for the element.
`autocomplete` | Specifies whether the browser should attempt to automatically complete the input based on user inputs to similar fields.
`border` | Was used to specify a border on an input. Deprecated. Use CSS instead.
`checked` | Specifies whether a checkbox or radio button form input should be checked by default.
`disabled` | Disables the input field.
`maxlength` | Specifies the maximum number of characters that can be entered in a text-type input.
`language` | Was used to indicate the scripting language used for events triggered by the input.
`name` | Specifies the name of an input element. The name and value of each input element are included in the HTTP request when the form is submitted.
`size` | Specifies the width of the input in characters.
`src` | Defines the source URL for an image input.
`type` |  Defines the input type.
`value` | Defines an initial value or default selection for an input field.






<script>
$(document).ready(function() {
  $('table').addClass('tablesort');
});
</script>
