using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;

namespace Catharsium.Util.Testing.Reflection;

public class TargetFactory<T>(IConstructorFilter constructorFilter) : ITargetFactory<T> where T : class
{
    private readonly IConstructorFilter constructorFilter = constructorFilter;


    public T CreateTarget(List<Dependency> dependencies) {
        var constructor = this.constructorFilter.GetLargestEligibleConstructor(typeof(T), dependencies);
        if(constructor == null) {
            return null;
        }

        var parameters = constructor.GetParameters();
        var arguments = new List<object>();
        foreach(var parameter in parameters) {
            var dependency = dependencies.FirstOrDefault(d => d.Type == parameter.ParameterType && d.Name == parameter.Name) ??
                             dependencies.FirstOrDefault(d => d.Type == parameter.ParameterType);

            if(dependency == null) {
                return null;
            }

            arguments.Add(dependency.Value);
        }

        return constructor.Invoke(arguments.ToArray()) as T;
    }
}