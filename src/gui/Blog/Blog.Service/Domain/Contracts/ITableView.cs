using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Other;
using Blog.Service.Domain.TableView;

namespace Blog.Service.Domain.Contracts;

public interface ITableView<TTableView, TModel> 
    where TModel : new()
    where TTableView : ITableView<TTableView, TModel>
{
    public static abstract explicit operator TModel(TTableView other);

    public TModel CastToModel()
    {
        TModel result = new();

        var viewProperties = PropertyAttribute<CopyToPropertyAttribute<TModel>>.GetAllPropertiesInClass<TTableView>();

        foreach (var property in viewProperties)
        {
            var value = property.GetPropertyValueRaw(this);
            var modelPropertyName = property.Attribute.Name;
            result.GetType()?.GetProperty(modelPropertyName)?.SetValue(result, value);
        }

        return result;
    }

}
