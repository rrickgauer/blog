using Blog.Service.Mappers.Tables;
using System.Data;

namespace Blog.Service.Services.Contracts;

public interface ITableMapperService
{
    public T ToModel<T>(DataRow dataRow);
    public IEnumerable<T> ToModels<T>(DataTable dataTable);
    public TableMapper<T> GetMapper<T>();

}
