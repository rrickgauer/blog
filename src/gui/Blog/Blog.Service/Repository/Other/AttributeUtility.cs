using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Blog.Service.Repository.Other;

public static class AttributeUtility
{

    public static string GetDescription<TEnum>(TEnum key) where TEnum : struct, Enum
    {
        return GetAttribute<TEnum, DescriptionAttribute>(key).Description;
    }

    public static TAttribute GetAttribute<TEnum, TAttribute>(TEnum key)
        where TAttribute : Attribute
        where TEnum : struct, Enum
    {
        if (!TryGetAttribute<TEnum, TAttribute>(key, out var value))
        {
            throw new ArgumentException(null, nameof(TAttribute));
        }

        return value;
    }


    public static bool TryGetAttribute<TEnum, TAttribute>(TEnum key, [NotNullWhen(true)] out TAttribute? attribute)
        where TEnum : struct, Enum
        where TAttribute : Attribute
    {
        var enumName = Enum.GetName(key);

        var field = typeof(TEnum).GetField(enumName!);

        if (field?.GetCustomAttribute<TAttribute>() is TAttribute result)
        {
            attribute = result;
        }
        else
        {
            attribute = null;
        }

        return attribute is not null;
    }


    public static bool TryGetAttribute<TAttr>(this PropertyInfo property, [NotNullWhen(true)] out TAttr? result) where TAttr : Attribute
    {
        result = property.GetCustomAttribute<TAttr>();
        return result != null;
    }

}


