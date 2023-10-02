using System.Reflection;

namespace BlogPilot.Services.Utilities;

public static class AttributeUtilities
{
    /// <summary>
    /// Get the specified attribute assignment for the property
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <typeparam name="TClass"></typeparam>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public static TAttribute? GetPropertyAttribute<TAttribute, TClass>(string propertyName) where TAttribute : Attribute
    {
        return GetPropertyAttribute<TAttribute>(propertyName, typeof(TClass));
    }

    /// <summary>
    /// Get the specified attribute assignment for the property
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="propertyName"></param>
    /// <param name="classType"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static TAttribute? GetPropertyAttribute<TAttribute>(string propertyName, Type classType) where TAttribute : Attribute
    {
        return classType.GetProperty(propertyName)?.GetCustomAttribute<TAttribute>();
    }
}
