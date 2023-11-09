using Blog.Service.Mappers.Tables;
using Blog.Service.Services.Contracts;
using System.Data;
using System.Reflection;

namespace Blog.Service.Services.Implementations;

public class TableMapperService : ITableMapperService
{
    private static readonly List<object> ModelMappers = GetAllModelMappers().ToList();

    #region - Fetch all model mappers -

    /// <summary>
    /// Get a list of each model mapper instantiation
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<object> GetAllModelMappers()
    {
        var subclassTypes = GetModelMapperSubclassTypes();

        var modelMapperObjects = subclassTypes.Select(t => Activator.CreateInstance(t));

        return modelMapperObjects.ToList();
    }

    /// <summary>
    /// Get each type of model mapper
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<Type> GetModelMapperSubclassTypes()
    {
        Type modelMapperType = typeof(TableMapper<>);
        Assembly assembly = Assembly.GetExecutingAssembly(); // Or use the assembly containing the classes you want to inspect
        var subclasses = assembly.GetTypes().Where(t => IsSubclassOfGeneric(t, modelMapperType) && !t.IsAbstract);

        return subclasses;
    }

    /// <summary>
    /// Check if generic
    /// </summary>
    /// <param name="current"></param>
    /// <param name="genericBase"></param>
    /// <returns></returns>
    private static bool IsSubclassOfGeneric(Type current, Type genericBase)
    {
        do
        {
            if (current.IsGenericType && current.GetGenericTypeDefinition() == genericBase)
            {
                return true;
            }
        }
        while ((current = current.BaseType) != null);

        return false;

    }

    #endregion


    public T ToModel<T>(DataRow dataRow)
    {
        return GetMapper<T>().ToModel(dataRow);
    }

    public IEnumerable<T> ToModels<T>(DataTable dataTable)
    {
        return GetMapper<T>().ToModels(dataTable);
    }

    public TableMapper<T> GetMapper<T>()
    {
        TableMapper<T>? correctMapper = null;

        foreach (var mapper in ModelMappers)
        {
            var castAttempt = mapper as TableMapper<T>;

            if (castAttempt != null)
            {
                correctMapper = castAttempt;
                break;
            }
        }

        if (correctMapper == null)
        {
            throw new NotSupportedException($"Model type {typeof(T)} is not supported.");
        }

        return correctMapper;
    }

}