using BlogPilot.Services.Mapping.ModelMapping;
using BlogPilot.Services.Service.Interface;
using System.Data;
using System.Reflection;

namespace BlogPilot.Services.Service.Implementation;

public class ModelMapperService : IModelMapperService
{
    //private static List<object> ModelMappers = new();
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
        Type modelMapperType = typeof(ModelMapper<>);
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


    /// <summary>
    /// Map the specified data row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataRow"></param>
    /// <returns></returns>
    public T ToModel<T>(DataRow dataRow)
    {
        var mapper = GetMapper<T>();
        return mapper.ToModel(dataRow);
    }

    /// <summary>
    /// Map the specified data table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataTable"></param>
    /// <returns></returns>
    public IEnumerable<T> ToModels<T>(DataTable dataTable)
    {
        var mapper = GetMapper<T>();
        return mapper.ToModels(dataTable);
    }


    /// <summary>
    /// Get the appropriate mapper for the specified model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public ModelMapper<T> GetMapper<T>()
    {
        ModelMapper<T>? correctMapper = null;

        foreach (var mapper in ModelMappers)
        {
            var castAttempt = mapper as ModelMapper<T>;

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
