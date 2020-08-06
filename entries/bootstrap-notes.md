# Bootstrap Notes

This is where I will be keeping some code snippets of some common bootstrap elements I use.

## Content

1. [Navbar](#navbar)
2. [Collapsing Sidebar](#collapsing-sidebar)
3. [Toolbar](#toolbar)
4. [Form Group](#form-group)


## Navbar

```html
<section id="navbar">
  <nav class="navbar navbar-expand-lg">
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown">
      <i class='bx bx-menu'></i>
    </button>

    <div class="collapse navbar-collapse" id="navbarNavDropdown">
      <ul class="navbar-nav">
        <li class="nav-item"><a class="nav-link" id="nav-item-home" href="index.php">Home</a></li>
        <li class="nav-item"><a class="nav-link" id="nav-item-new-project" href="new-project.php">New Project</a></li>
      </ul>
    </div>
  </nav>
</section>
```

## Collapsing Sidebar

### HTML

```html
<div class="wrapper">

  <nav id="sidebar">
    <ul>
      <!-- sidebar links go here: -->
      <li class="active"><a href="#">Home</a></li>
      <li><a href="#">Page 2</a></li>
      <li><a href="#">Page 3</a></li>
      <li><a href="#">Page 4</a></li>      
    </ul>
  </nav>

  <!-- page content goes here -->
  <div id="content">
    <div class="container-fluid">
      <button type="button" onclick="activateSidebar()">View checklists</button>
    </div>
  </div>

</div>
```

### CSS
```css
.wrapper {
   display: flex;
   width: 100%;
   align-items: stretch;
}

#sidebar {
   transition: all 0.2s;
   min-width: 250px;
   max-width: 250px;
   min-height: 100vh;
}

#sidebar.active {
   margin-left: -250px;
}
```

### JavaScript

Add a button so that when clicked it will call ```activateSidebar()```.

```js
function activateSidebar() {
  $('#sidebar').toggleClass('active');
}
```

## Toolbar

This is a simple code snippet of a toolbar with a group of buttons on one side, and a search bar on the other. 

### HTML

```html
<div class="toolbar">
  <div class="buttons">
    <button class="btn btn-secondary">Button</button>
    <button class="btn btn-secondary">Button</button>
    <div class="dropdown">
      <button class="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown">
        Dropdown
      </button>
      <div class="dropdown-menu">
        <a class="dropdown-item" href="#">Action</a>
        <a class="dropdown-item" href="#">Another action</a>
        <a class="dropdown-item" href="#">Something else here</a>
      </div>
    </div>
  </div>

  <div class="input">
    <input type="text" name="search" class="form-control" placeholder="Search...">
  </div>
</div>
```

### CSS

```css
.toolbar {
    display: flex;
    justify-content: space-between;
}

.toolbar .buttons {
    display: flex;
    justify-content: space-around;
}

.toolbar .buttons > * {
    margin-right: 3px;
    margin-left: 3px;
}

.toolbar .input .form-control {
    width: 100%;
}
```

## Form Group

This is a simple [form group](https://getbootstrap.com/docs/4.5/components/forms/#form-groups) that includes an [input group](https://getbootstrap.com/docs/4.5/components/input-group/).

```html
<div class="form-group">
  <label for="new-email">Email address</label>
  <div class="input-group">
    <div class="input-group-prepend">
      <span class="input-group-text">@</span>
    </div>
    <input type="email" class="form-control" id="new-email" name="new-email">
  </div>
</div>
```

<img src="https://static.bookstack.cn/projects/bootstrap-v4.3-en/61d1df6f588286e2e1210165473cc5f8">

