using Catharsium.Util.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Catharsium.Util.Testing.Reflection
{
    public class ConstructorFilter<T> : IConstructorFilter<T>
    {
        public ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies = null)
        {
            return this.GetEligibleConstructors(dependencies).OrderBy(c => c.GetParameters().Length)
                                                             .LastOrDefault();
        }

        
        public IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies)
        {
            return dependencies != null && dependencies.Any()
                ? this.GetEligibleConstructors(dependencies.Keys)
                : this.GetEligibleConstructors(null as List<Type>);
        }


        public IEnumerable<ConstructorInfo> GetEligibleConstructors(IEnumerable<Type> dependencies)
        {
            var constructors = typeof(T).GetConstructors();
            return dependencies != null && dependencies.Any()
                ? constructors.Where(c => c.GetParameters().All(p => dependencies.Contains(p.ParameterType)))
                : constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface));
        }
    }
}