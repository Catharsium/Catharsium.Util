using Catharsium.Util.Testing.Interfaces;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing
{
    public class TargetFactory<T> : ITargetFactory<T> where T : class
    {
        private readonly IConstructorFilter<T> constructorFilter;


        public TargetFactory(IConstructorFilter<T> constructorFilter) {
            this.constructorFilter = constructorFilter;
        }


        public T CreateTarget(Dictionary<Type, object> dependencies)
        {
            var constructor = this.constructorFilter.GetLargestEligibleConstructor(dependencies);
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
    }
}