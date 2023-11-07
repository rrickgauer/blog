using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Other;

namespace Blog.Service.Domain.Contracts;

public interface ITableView<TTableView, TModel> 
    where TModel : new()
    where TTableView : ITableView<TTableView, TModel>
{
    public static abstract explicit operator TModel(TTableView other);

    private static IEnumerable<PropertyAttribute<CopyToPropertyAttribute<TModel>>> ViewProperties => PropertyAttribute<CopyToPropertyAttribute<TModel>>.GetAllPropertiesInClass<TTableView>();

    public TModel CastToModel()
    {
        TModel result = new();

        foreach (var property in ViewProperties)
        {
            var value = property.GetPropertyValueRaw(this);
            var modelPropertyName = property.Attribute.Name;
            result.GetType()?.GetProperty(modelPropertyName)?.SetValue(result, value);
        }

        return result;
    }

}
