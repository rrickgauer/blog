# Background
This is where I will be keeping my code snippets and notes I have on the popular python plotting library [Matplotlib](https://matplotlib.org/). As of now, I am making this to use as a quick reference for my [Machine Learning class](https://github.com/rrickgauer/NIU-Undergrad/tree/master/CSCI-490).

## Basics

### Template
```python
import matplotlib.pyplot as plt
import matplotlib.patches as mpatches
import numpy as np

data = getData()
x = data['x']
y = data['y']

fig, ax = plt.subplots(1, 1)  # create 2 subplots

ax[0, 0].plot(x=x, y=y, title='Left Graph', color='red', marker='o')
ax[0, 0].set_xlabel('X Label - Graph 1')
ax[0, 0].set_ylabel('Y Label - Graph 1')
ax[0, 0].set_xticks([1, 2, 3, 4, 5])
ax[0, 0].set_yticks([10, 20, 30, 40, 50])

ax[0, 1].scatter(x=x, y=y, title='Right Graph', color='blue', marker='x')
ax[0, 1].set_xlabel('X Label - Graph 2')
ax[0, 1].set_ylabel('Y Label - Graph 2')
ax[0, 1].set_xticks(np.arrange(1, 5, 1.0))
ax[0, 1].set_yticks(np.arrange(10, 50, 10.0))

plt.tight_layout()
plt.show()
```

## Graph Types
```python
plt.plot(x, y)
plt.scatter(x, y)
plt.bar(names, values)
plt.hist(data, bins)
```

## Common Graph Properties
Some common properties to include in the plot and scatter graphs function include:

* [Complete list](https://matplotlib.org/api/_as_gen/matplotlib.lines.Line2D.html#matplotlib.lines.Line2D)
* x
* y
* label
* color
* marker
   * [list](https://matplotlib.org/api/markers_api.html#module-matplotlib.markers) of all available markers

## Subplots
To break the graph into subplots, do the following:
```python
fig, axs = plt.subplots(4, 4)                               # create 16 subplots

x = [1, 5, 7]                                               # x data
y = [20, 56, 3]                                             # y data
axs[0, 1].plot(x=x, y=y, label='First Subplot')     # axs[row, column]

x = [23, 56, 89]                                            # x data
y = [101, 23, 67]                                           # y data
axs[0, 2].plot(x=x, y=y, label='Second Subplot')    # axs[row, column]
```


## Plotting 2 different datasets on the same graph
* [Example](https://www.tylervigen.com/spurious-correlations)
* Here, we want to plot 2 datasets with different values for the x and y axis on the same graph

```python
movies    = np.array([2, 2, 2, 3, 1, 1, 2, 3, 4, 1, 4])
years     = np.array([1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009])
drownings = np.array([109, 102, 102, 98, 85, 95, 96, 98, 123, 94, 102])

fig, ax1 = plt.subplots()

# plot swimming pool drownings
color = 'tab:red'
ax1.set_xlabel('Years')
ax1.set_ylabel('Swimming pool drownings', color=color)
ax1.plot(years, drownings, color=color, marker='o')
ax1.tick_params(axis='y', labelcolor=color)
plt.yticks((80, 120 , 160))

# plot nick cage movie
color = 'tab:blue'                                 # change plot color
ax2 = ax1.twinx()                                  # instantiate a second axes that shares the same x-axis
ax2.set_ylabel('Nicholas Cage', color=color)       # we already handled the x-label with ax1
ax2.plot(years, movies, color=color, marker='x')
ax2.tick_params(axis='y', labelcolor=color)
plt.yticks((0, 4 , 8))

fig.tight_layout()
plt.xticks(np.arange(min(years), max(years)+1, 1.0))

plt.show()
```

## Labels, Titles, and Ticks

### Documentation
* [Labels and titles](https://matplotlib.org/3.1.3/api/axes_api.html#ticks-and-tick-labels)
* [Tick marks](https://matplotlib.org/3.1.3/api/axes_api.html#ticks-and-tick-labels)

### Axis Labels
```python
axs.set_xlabel('X label')
axs.set_ylabel('Y label')
```

### Titles
```python
axs.set_title('This is the title')
```

### Ticks
There are a few different ways to set the x and y tick marks.

One way is to create an ```np.array()``` comprised of the desired tick mark values:
```python
axs.set_yticks([1, 2, 3, 4, 5, 6, 7])
axs.set_xticks([45, 50, 100, 200, 300])
```

If you don't have a few number of ticks that you want to use, you can use the following to arrange them:
```python
yticks = np.arrange(0, 100, 2.5)                   # np.arrange(min, max, incrementor)
xticks = np.arrange(min(x), max(x), 1.0)   # np.arrange(min, max, incrementor)

axs.set_yticks(yticks)
axs.set_xticks(xticks)

# or you could do
axs.set(yticks=yticks, xticks=xticks)
```

## Legends
* [Official documentation](https://matplotlib.org/3.1.3/tutorials/intermediate/legend_guide.html)

### Legend Location
```python
axs.set_legend(loc=2)
```

Location String | Location Code
----------------|--------------
'best'|0
'upper right'| 1
'upper left'| 2
'lower left'| 3
'lower right'| 4
'right' | 5
'center left' | 6
'center right' | 7
'lower center' | 8
'upper center' | 9
'center' | 10


### Custom Legend
```python
import matplotlib.patches as mpatches

blue_patch = mpatches.Patch(color='blue', label='setosa')       # setosa legend key
red_patch = mpatches.Patch(color='red', label='versicolor')     # versicolor legend key
green_patch = mpatches.Patch(color='green', label='virginica')  # virginica legend key
fig.legend(handles=[blue_patch, red_patch, green_patch])
```

## General Appearance

### Tight Layout
To make the graph look better, you can use:
```python
plt.tight_layout()
```

### White Space

* You can adjust the spacing between subplots by altering the figure's width space (**wspace**) and its height space (**hspace**).
* To compact all the subplots, set *wspace* and *hspace* equal to 0 by doing this:
```python
fig.subplots_adjust(wspace=0)    # adjust width spacing
fig.subplots_adjust(hspace=0)    # adjust height spacing
```
