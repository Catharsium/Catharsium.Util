using Catharsium.Util.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Catharsium.Util.Testing.Reflection
{
    public class ConstructorFilter : IConstructorFilter
    {
        public IEnumerable<Type> AllowedDependencies { get; }


        public ConstructorFilter(IEnumerable<Type> allowedDependencies)
        {
            this.AllowedDependencies = allowedDependencies;
        }


        public ConstructorInfo GetLargestEligibleConstructor(Type type, Dictionary<Type, object> dependencies = null)
        {
            return this.GetEligibleConstructors(type, dependencies)
                .OrderBy(c => c.GetParameters().Length)
                .LastOrDefault();
        }

        
        public IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, Dictionary<Type, object> dependencies)
        {
            return dependencies != null && dependencies.Any()
                ? this.GetEligibleConstructors(type, dependencies.Keys)
                : this.GetEligibleConstructors(type, null as List<Type>);
        }


        public IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, IEnumerable<Type> dependencies = null)
        {
            var constructors = type.GetConstructors();
            return dependencies != null && dependencies.Any()
                ? constructors.Where(c => c.GetParameters().All(p => dependencies.Contains(p.ParameterType)))
                : constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface || this.AllowedDependencies.Contains(p.ParameterType)));
        }
    }
}