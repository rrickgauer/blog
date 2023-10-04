using BlogPilot.Services.Domain.Helpers;
using System.ComponentModel;
using System.Reflection;

namespace BlogPilot.Services.Utilities;

public static class EnumUtilities
{

    public static IEnumerable<EnumDescription<T>> GetDescriptions<T>() where T : Enum
    {
        return ToCollection<T>().Select(v => new EnumDescription<T>(v));
    }

    public static IEnumerable<T> ToCollection<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static string GetDescription<T>(T value) where T : Enum
    {
        string enumName = Enum.GetName(typeof(T), value) ?? value.ToString();

        var field = typeof(T).GetFields().Where(f => f.Name == enumName).First();

        var customAttr = field.GetCustomAttribute<DescriptionAttribute>();

        if (customAttr == null)
        {
            return enumName;
        }

        return customAttr.Description;
    }





}
