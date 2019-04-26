﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catharsium.Util.Testing.Configuration;
using Catharsium.Util.Testing.Interfaces;
using NSubstitute;

namespace Catharsium.Util.Testing
{
    public class DependencyRetriever : IDependencyRetriever
    {
        private readonly ISubstituteFactory substituteFactory;


        public DependencyRetriever(ISubstituteFactory substituteFactory)
        {
            this.substituteFactory = substituteFactory;
        }


        public Dictionary<Type, object> GetDependencySubstitutes<T>()
        {
            var dependencies = this.GetDependencies<T>();
            var result = new Dictionary<Type, object>();
            foreach(var dependency in dependencies)
            {
                result[dependency] = this.substituteFactory.GetSubstitute(dependency);
            }
            return result;
        }


        public Dictionary<Type, object> GetDependencySubstitutes(ConstructorInfo constructor, Dictionary<Type, object> substitutes)
        {
            var dependencies = new List<Type>();

            if (constructor != null)
            {
                var parameters = constructor.GetParameters().Where(p => p.ParameterType.IsInterface || SupportedDependencies.Types.Contains(p.ParameterType));
                dependencies.AddRange(parameters.Select(p => p.ParameterType));
            }

            var result = new Dictionary<Type, object>();
            foreach (var dependency in dependencies)
            {
                result[dependency] = substitutes[dependency];
            }
            return result;
        }


        public IEnumerable<Type> GetDependencies<T>()
        {
            var constructors = typeof(T).GetConstructors();
            var result = new List<Type>();
            foreach (var constructor in constructors)
            {
                foreach (var dependency in constructor.GetParameters().Where(p => p.ParameterType.IsInterface || SupportedDependencies.Types.Contains(p.ParameterType)))
                {
                    if (!result.Contains(dependency.ParameterType))
                    {
                        result.Add(dependency.ParameterType);
                    }
                }
            }

            return result;
        }


        public Dictionary<Type, object> GetSubstitutes(IEnumerable<Type> dependencies)
        {
            var result = new Dictionary<Type, object>();

            foreach (var dependency in dependencies)
            {
                var substitute = Substitute.For(new[] { dependency }, Array.Empty<object>());
                result.Add(dependency, substitute);
            }

            return result;
        }
    }
}