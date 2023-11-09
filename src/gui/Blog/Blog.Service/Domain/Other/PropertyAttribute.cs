using Blog.Service.Domain.Model;
using System.Reflection;

namespace Blog.Service.Domain.Other;

public sealed class PropertyAttribute<TAttribute> where TAttribute : Attribute
{
    public static Type AttributeType => typeof(TAttribute);

    public PropertyInfo PropertyInfo { get; private set; }
    public TAttribute Attribute { get; private set; }


    public PropertyAttribute(PropertyInfo propertyInfo, TAttribute attribute)
    {
        PropertyInfo = propertyInfo;
        Attribute = attribute;
    }

    public PropertyAttribute(PropertyInfo propertyInfo)
    {
        PropertyInfo = propertyInfo;
        Attribute = GetAttribute(propertyInfo);
    }

    /// <summary>
    /// Get the attribute for the specified property
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    private static TAttribute GetAttribute(PropertyInfo propertyInfo)
    {
        var attr = propertyInfo.GetCustomAttribute<TAttribute>(true);

        if (attr is null)
        {
            throw new NotSupportedException($"{propertyInfo.Name} does not have the custom attribute {nameof(TAttribute)}");
        }

        return attr;
    }

    /// <summary>
    /// Get the property value as a nullable object
    /// </summary>
    /// <param name="classData"></param>
    /// <returns></returns>
    public object? GetPropertyValueRaw(object? classData)
    {
        return GetPropertyValue<object?>(classData);
    }

    /// <summary>
    /// Get the property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="classInstance"></param>
    /// <returns></returns>
    public T? GetPropertyValue<T>(object? classInstance) where T : class?
    {
        return PropertyInfo.GetValue(classInstance) as T;
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
