namespace Blog.Service.Domain.Other;

public class ClassPropertyAttributes<TAttribute> where TAttribute : Attribute
{
    public static Type AttributeType => typeof(TAttribute);
    
    public List<PropertyAttribute<TAttribute>> PropertyAttributes { get; private set; }
    public Type ClassType { get; private set; }

    public ClassPropertyAttributes(Type classType)
    {
        ClassType = classType;
        PropertyAttributes = PropertyAttribute<TAttribute>.GetAllPropertiesInClass(ClassType).ToList();
    }

    public PropertyAttribute<TAttribute>? Get(string propertyName)
    {
        return PropertyAttributes.Where(p => p.PropertyInfo.Name == propertyName).FirstOrDefault();
    }

}
