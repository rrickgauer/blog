
This is an example of calling a [Jinja macro](https://jinja.palletsprojects.com/en/3.1.x/templates/#macros) in python to get its output.

## Jinja Macro File

Here is a simple macro that takes in a collection of user objects and makes a list of HTML items. The file is named `users-macro.html`.

```html
{% macro create_users_list(users) -%}
  
  <ul>
    {% for user in happenings %}
        <li data-user-id="{{ user.id }}">{{ user.name_first }} {{ user.name_last }}</li>
    {% endfor %}
  </ul>

{%- endmacro %}
```


## Calling the macro

Let's create a function that calls a jinja macro:

```py
import flask

def run_jinja_macro(file_name: str, macro: str, *args):
    jinja_macro = flask.get_template_attribute(file_name, macro)
    
    result = jinja_macro(*args)

    return result
```


To call this function:

```py

# data for the macro
users = [
    dict(id=1, name_first='Ryan', name_last='Rickgauer'),
    dict(id=2, name_first='George', name_last='Washington'),
    dict(id=3, name_first='John', name_last='Smith'),
]

html = run_jinja_macro('users-macro.html', 'create_users_list', users)

print(html)
```
