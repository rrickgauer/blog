namespace BlogPilot.Services.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class SqlColumnAttribute : Attribute
{
    public string ColumnName { get; private set; }

    public SqlColumnAttribute(string columnName)
    {
        ColumnName = columnName;
    }
}
