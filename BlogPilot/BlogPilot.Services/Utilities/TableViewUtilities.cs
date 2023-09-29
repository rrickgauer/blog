using BlogPilot.Services.Domain.Attributes;
using BlogPilot.Services.Domain.TableViews;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Utilities;

public static class TableViewUtilities
{
    /// <summary>
    /// Copy the appropriate TView property values into a new TModel object
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="view"></param>
    /// <returns></returns>
    public static TModel CopyTableViewProperties<TView, TModel>(TView view)
        where TView : ITableView
        where TModel : class, new()
    {
        TModel result = new();

        // get the properties of each class
        var viewProperties = ReflectionUtilities.GetClassProperties<TView>();
        var modelProperties = ReflectionUtilities.GetClassProperties<TModel>();

        foreach (var viewProperty in viewProperties.Values)
        {
            // see if the property has a CopyToModelAttribute assignment whose ModelType matches TModel
            var customAttribute = viewProperty.GetCustomAttributes<CopyToModelAttribute>().Where(a => a.ModelType == typeof(TModel)).FirstOrDefault();
            
            if (customAttribute != null)
            {
                // we have a match.. so copy over the value from the view to the model
                var propertyValue = viewProperty.GetValue(view);
                modelProperties[customAttribute.PropertyName].SetValue(result, propertyValue);
            }
        }

        return result;
    }

}
