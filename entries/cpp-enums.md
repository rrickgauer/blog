
This is a quick review on enums in C++.

To create an enum:

```cpp
enum class FoodCategories {
    VEGETABLES,
    FRUIT,
    MEAT,
    DAIRY,
};
```

To use `FoodCategories`:

```cpp
std::cout << (short)FoodCategories::VEGETABLES << std::endl;    // 0
std::cout << (short)FoodCategories::FRUIT << std::endl;         // 1
std::cout << (short)FoodCategories::MEAT << std::endl;          // 2
std::cout << (short)FoodCategories::DAIRY << std::endl;         // 3
```

You can also use enums as a return type for functions:

```cpp
static FoodCategories getVegetables()
{
    return FoodCategories::VEGETABLES;
}

static FoodCategories getFruit()
{
    return FoodCategories::FRUIT;
}

static FoodCategories getMeat()
{
    return FoodCategories::MEAT;
}

static FoodCategories getDairy()
{
    return FoodCategories::DAIRY;
}
```

Furthermore, you can use them in switch/if-statements:

```cpp
FoodCategories foodCategory = getVegetables();

switch (foodCategory)
{
    case FoodCategories::VEGETABLES:
        std::cout << "Veggies";
        break;

    case FoodCategories::FRUIT:
        std::cout << "Fruit";
        break;

    case FoodCategories::MEAT:
        std::cout << "Meat";
        break;

    case FoodCategories::DAIRY:
        std::cout << "Dairy";
        break;
}
```
