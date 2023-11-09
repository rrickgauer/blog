using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Other;
using System.Data;

namespace Blog.Service.Mappers.Tables;

public abstract class TableMapper<T>
{
    public abstract T ToModel(DataRow row);

    public static Type ModelType => typeof(T);
    protected static readonly ClassPropertyAttributes<SqlColumnAttribute> SqlColumnProperties = new(ModelType);

    public IEnumerable<T> ToModels(DataTable table)
    {
        List<T> models = new();

        foreach (DataRow row in table.AsEnumerable())
        {
            var model = ToModel(row);
            models.Add(model);
        }

        return models;
    }

    protected static string GetColumnName(string propertyName)
    {
        var prop = SqlColumnProperties.Get(propertyName);

        if (prop == null)
        {
            throw new NotSupportedException($"{propertyName} is not a valid property in this class");
        }

        return prop.Attribute.ColumnName;
    }
}
