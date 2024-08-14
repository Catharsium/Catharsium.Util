using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using System.Reflection;

namespace Catharsium.Util.Testing.Reflection;

public class ConstructorFilter(IEnumerable<Type> allowedDependencies) : IConstructorFilter
{
    public IEnumerable<Type> AllowedDependencies { get; } = allowedDependencies;


    public ConstructorInfo GetLargestEligibleConstructor(Type type, List<Dependency> dependencies = null) {
        return this.GetEligibleConstructors(type, dependencies)
            .OrderBy(c => c.GetParameters().Length)
            .LastOrDefault();
    }


    public IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, List<Dependency> dependencies) {
        return dependencies != null && dependencies.Count != 0
            ? this.GetEligibleConstructors(type, dependencies.Select(d => d.Type).ToList())
            : this.GetEligibleConstructors(type, null as List<Type>);
    }


    public IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, List<Type> dependencies = null) {
        var constructors = type.GetConstructors();
        return dependencies != null && dependencies.Count != 0
            ? constructors.Where(c => c.GetParameters().All(p => dependencies.Contains(p.ParameterType)))
            : constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface ||
                                                                 this.AllowedDependencies.Any(d => d.IsAssignableFrom(p.ParameterType))));
    }
}