using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using PropertyDict = System.Collections.Generic.Dictionary<string, System.Reflection.PropertyInfo>;

namespace BlogPilot.Services.Utilities;

public static class ReflectionUtilities
{
    /// <summary>
    /// Get a (PropertyName, PropertyInfo) Dictionary of the specified type's properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static PropertyDict GetClassProperties<T>()
    {
        var properties = typeof(T).GetProperties();

        PropertyDict result = new(properties.Select(p => ToKeyValuePair(p)));

        return result;
    }

    private static KeyValuePair<string, PropertyInfo> ToKeyValuePair(PropertyInfo propertyInfo)
    {
        return new(propertyInfo.Name, propertyInfo);
    }



}
