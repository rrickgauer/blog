using System.Runtime.CompilerServices;

namespace Blog.Service.Domain.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class SqlColumnAttribute : Attribute
{
    public string ColumnName { get; }

    public SqlColumnAttribute([CallerMemberName] string columnName="")
    {
        ColumnName = columnName;
    }
}
