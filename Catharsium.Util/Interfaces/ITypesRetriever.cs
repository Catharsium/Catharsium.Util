using System.Reflection;
namespace Catharsium.Util.Interfaces;

public interface ITypesRetriever
{
    IEnumerable<Type> GetImplementationsFor<T>(Assembly[] assemblies);
    IEnumerable<Type> GetImplementationsFor<T>(Assembly assembly);
    IEnumerable<Type> GetImplementationsFor<T>();
}