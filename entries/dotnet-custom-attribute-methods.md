

These functions are some that I use for handling custom attributes for properties in my C# classes.


```csharp
/// <summary>
/// Get a list of PropertyInfo's of the given source Type that are assigned the specified attribute
/// </summary>
/// <param name="source"></param>
/// <param name="attribute"></param>
/// <returns></returns>
public static List<PropertyInfo> GetPropertiesWithAttribute(Type source, Type attribute)
{
    List<PropertyInfo> properties = (source).GetProperties().Where(x => x.GetCustomAttributes(attribute, true).Any()).ToList();

    return properties ?? new();
}

/// <summary>
/// Get the specified CustomAttribute from the given PropertyInfo
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="prop"></param>
/// <returns></returns>
public static T? GetAttributeFromProperty<T>(PropertyInfo prop)
{
    var propertyCustomAttributes = prop.GetCustomAttributes(false);
    var customAttr = propertyCustomAttributes.Where(x => x.GetType().Name == typeof(T).Name).FirstOrDefault();

    if (customAttr is null)
    {
        return default;
    }

    return (T)customAttr;
}
```


## Example


Let's take a look at how to use these methods.



### Custom Attribute Class

Here is a custom attribute class that I created:


```csharp
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class SqlSelectColumnsAttribute : Attribute, ISqlColumnAttribute
{
    public string Name { get; set; }

    public SqlSelectColumnsAttribute(string name)
    {
        Name = name;
    }
}
```

### Attribute Usage


Here is a class with some prperties that use the `SqlSelectColumnsAttribute` attribute:

```csharp
public class Topic
{
    [SqlSelectColumns("topic_id")]
    public uint? Id { get; set; }

    [SqlSelectColumns("topic_name")]
    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }
}
```


### Using the attribute methods

To use the mapper utility methods:

```csharp
// get a list of PropertyInfos that have the SqlSelectColumns attribute
List<PropertyInfo> propertiesWithAttribute = GetPropertiesWithAttribute(typeof(Topic), typeof(SqlSelectColumnsAttribute));  // Id, Name

// print each property attribute name
foreach (var prop in propertiesWithAttribute)
{
    SqlSelectColumnsAttribute? attr = GetAttributeFromProperty<SqlSelectColumnsAttribute>(prop);

    var attributeColumnValue = attr.Name;
    var propertyName = prop.Name;

    Console.WriteLine($"The attribute value for {propertyName} is: {attributeColumnValue}");
}
```