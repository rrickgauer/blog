using BlogPilot.Services.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Utilities;

public static class DataRowUtilities
{
    public static TColumnType? GetSqlColumn<TModel, TColumnType>(this DataRow row, string propertyName)
    {
        var columnName = AttributeUtilities.GetPropertyAttribute<SqlColumnAttribute, TModel>(propertyName)?.ColumnName;

        if (columnName == null)
            return default;

        return row.Field<TColumnType>(columnName);
    }
}
