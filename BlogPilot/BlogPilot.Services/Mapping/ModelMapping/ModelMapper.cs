using BlogPilot.Services.Utilities;
using System.Data;

namespace BlogPilot.Services.Mapping.ModelMapping;

public abstract class ModelMapper<T>
{
    public abstract T ToModel(DataRow dataRow);

    public IEnumerable<T> ToModels(DataTable dataTable)
    {
        List<T> models = new();

        foreach (DataRow dataRow in dataTable.Rows)
        {
            var model = ToModel(dataRow);
            models.Add(model);
        }

        return models;
    }


    protected TColumnType? GetSqlColumn<TColumnType>(DataRow dataRow, string propertyName)
    {
        return dataRow.GetSqlColumn<T, TColumnType>(propertyName);
    }
}
