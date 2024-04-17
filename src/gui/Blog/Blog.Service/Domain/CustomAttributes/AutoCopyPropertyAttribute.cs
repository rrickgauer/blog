using System.Runtime.CompilerServices;

namespace Blog.Service.Domain.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class AutoCopyPropertyAttribute(string modelPropertyName, [CallerMemberName] string viewPropertyName = "") : Attribute
{
    public string ModelPropertyName { get; } = modelPropertyName;
    public string ViewPropertyName { get; } = viewPropertyName;
}
