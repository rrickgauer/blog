---
title: MyPlanner Database Tables
created: '2020-04-02T03:16:09.345Z'
modified: '2020-04-02T03:56:27.548Z'
---

# MyPlanner Database Tables

### Users

<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>email</b></td><td>varchar(50), not null, unique</td></tr>
<tr><td><b>password</b></td><td>char(30), not null</td></tr>
</table>

### Labels
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>user_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>name</b></td><td>varchar(20)</td></tr>
<tr><td><b>color</b></td><td>char(7)</td></tr>
</table>

### Projects
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>user_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>name</b></td><td>varchar(100), not null</td></tr>
<tr><td><b>description</b></td><td>text</td></tr>
<tr><td><b>datetime_created</b></td><td>datetime, not null</td></tr>
<tr><td><b>date_due</b></td><td>datetime</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Project_Notes
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>project_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>content</b></td><td>text</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Project_Checklists
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>project_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>name</b></td><td>varchar(100), not null</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Project_Checklist_Items
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>project_checklist_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>content</b></td><td>text</td></tr>
<tr><td><b>completed</b></td><td>enum('n', 'y'), default 'n', not null</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Items
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>project_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>name</b></td><td>varchar(50), not null</td></tr>
<tr><td><b>description</b></td><td>text</td></tr>
<tr><td><b>date_created</b></td><td>datetime, not null</td></tr>
<tr><td><b>date_due</b></td><td>datetime</td></tr>
<tr><td><b>completed</b></td><td>enum('n', 'y'), default 'n', not null</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Item_Labels
<table>
<tr><td><b>item_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>label_id</b></td><td>int, unsigned, not null</td></tr>
</table>

### Item_Notes
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>item_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>content</b></td><td>text</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Item_Checklists
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>item_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>name</b></td><td>varchar(100), not null</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

### Item_Checklist_Items
<table>
<tr><td><b>id</b></td><td>int, unsigned, not null, unique, auto_increment</td></tr>
<tr><td><b>item_checklist_id</b></td><td>int, unsigned, not null</td></tr>
<tr><td><b>content</b></td><td>text</td></tr>
<tr><td><b>completed</b></td><td>enum('n', 'y'), default 'n', not null</td></tr>
<tr><td><b>display_index</b></td><td>int, unsigned, not null</td></tr>
</table>

