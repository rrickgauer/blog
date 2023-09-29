using BlogPilot.Services.Mapping.ModelMapping;
using System.Data;

namespace BlogPilot.Services.Service.Interface;

public interface IModelMapperService
{
    public T ToModel<T>(DataRow dataRow);
    public IEnumerable<T> ToModels<T>(DataTable dataTable);
    public ModelMapper<T> GetMapper<T>();
}
