using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catharsium.Util.Testing.Interfaces;

namespace Catharsium.Util.Testing
{
    public class TargetFactory<T> : ITargetFactory<T> where T : class
    {
        public T CreateTarget(Dictionary<Type, object> dependencies)
        {
            var constructor = this.GetLargestEligibleConstructor(dependencies);
            if (constructor == null)
            {
                return null;
            }

            var parameters = constructor.GetParameters();
            var arguments = new List<object>();
            foreach (var parameter in parameters)
            {
                if (!dependencies.ContainsKey(parameter.ParameterType))
                {
                    return null;
                }
                arguments.Add(dependencies[parameter.ParameterType]);
            }

            return constructor.Invoke(arguments.ToArray()) as T;
        }


        public ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies = null)
        {
            return this.GetEligibleConstructors(dependencies).OrderBy(c => c.GetParameters().Length)
                                                             .LastOrDefault();
        }


        public IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies)
        {
            var constructors = typeof(T).GetConstructors();
            return dependencies != null && dependencies.Keys.Any()
                ? constructors.Where(c => c.GetParameters().All(p => dependencies.ContainsKey(p.ParameterType)))
                : constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface));
        }
    }
}