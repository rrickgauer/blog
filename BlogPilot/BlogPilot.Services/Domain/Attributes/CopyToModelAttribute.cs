using System.Runtime.CompilerServices;

namespace BlogPilot.Services.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class CopyToModelAttribute : Attribute
{
    public Type ModelType { get; private set; }
    public string PropertyName { get; private set; }

    public CopyToModelAttribute(Type modelType, [CallerMemberName] string propertyName = "")
    {
        ModelType = modelType;
        PropertyName = propertyName;
    }

}
