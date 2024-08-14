using Catharsium.Util.Interfaces;
using System.Reflection;

namespace Catharsium.Util.Reflection.Types;

public class TypesRetriever : ITypesRetriever
{
    public IEnumerable<Type> GetImplementationsFor<T>(Assembly[] assemblies) {
        return assemblies.SelectMany(this.GetImplementationsFor<T>);
    }


    public IEnumerable<Type> GetImplementationsFor<T>(Assembly assembly) {
        return assembly.GetTypes().Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
    }


    public IEnumerable<Type> GetImplementationsFor<T>() {
        return this.GetImplementationsFor<T>(AppDomain.CurrentDomain.GetAssemblies());
    }
}