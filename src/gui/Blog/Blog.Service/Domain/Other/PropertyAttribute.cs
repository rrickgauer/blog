using System.Reflection;

namespace Blog.Service.Domain.Other;

public sealed class PropertyAttribute<TAttribute> where TAttribute : Attribute
{
    public static Type AttributeType => typeof(TAttribute);

    public PropertyInfo PropertyInfo { get; private set; }
    public TAttribute Attribute { get; private set; }

    public PropertyAttribute(PropertyInfo propertyInfo)
    {
        PropertyInfo = propertyInfo;
        Attribute = GetAttr(propertyInfo);
    }

    public PropertyAttribute(PropertyInfo propertyInfo, TAttribute attribute)
    {
        PropertyInfo = propertyInfo;
        Attribute = attribute;
    }

    private static TAttribute GetAttr(PropertyInfo propertyInfo)
    {
        var attr = propertyInfo.GetCustomAttribute<TAttribute>(true);

        if (attr is null)
        {
            throw new NotSupportedException($"{propertyInfo.Name} does not have the custom attribute {nameof(TAttribute)}");
        }

        return attr;
    }


    public object? GetPropertyValueRaw(object? classData)
    {
        return GetPropertyValue<object?>(classData);
    }

    public T? GetPropertyValue<T>(object? classData) where T : class?
    {
        return PropertyInfo.GetValue(classData) as T;
    }


    public static IEnumerable<PropertyAttribute<TAttribute>> GetAllPropertiesInClass<TClass>()
    {
        return GetAllPropertiesInClass(typeof(TClass));
    }

    public static IEnumerable<PropertyAttribute<TAttribute>> GetAllPropertiesInClass(Type classType)
    {
        var classProperties = classType.GetProperties().Where(p => p.GetCustomAttribute<TAttribute>() != null);

        var result = classProperties.Select(p => new PropertyAttribute<TAttribute>(p));

        return result;
    }
}
