using BlogPilot.Services.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogPilot.Services.Domain.Helpers;

public class EnumDescription<T> where T : System.Enum
{
    public T Value { get; set; }
    public string Description { get; private set; }

    public EnumDescription(T value)
    {
        Value = value;
        Description = EnumUtilities.GetDescription(value);
    }

    public EnumDescription(T value, string description)
    {
        Value = value;
        Description = description;
    }

    public static implicit operator T(EnumDescription<T> d) => d.Value;
}
