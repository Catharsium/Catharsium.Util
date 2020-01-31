using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Catharsium.Util.Testing.Reflection
{
    public class DependencyRetriever : IDependencyRetriever
    {
        private readonly ISubstituteService substituteFactory;
        private readonly IEnumerable<Type> supportedDependencies;


        public DependencyRetriever(ISubstituteService substituteFactory, IEnumerable<Type> supportedDependencies)
        {
            this.substituteFactory = substituteFactory;
            this.supportedDependencies = supportedDependencies;
        }


        public List<Dependency> GetDependencySubstitutes<T>()
        {
            var result = this.GetDependencies<T>();
            foreach (var dependency in result) {
                dependency.Value = this.substituteFactory.GetSubstitute(dependency.Type);
            }

            return result;
        }


        public List<Dependency> GetDependencySubstitutes(ConstructorInfo constructor, List<Dependency> substitutes)
        {
            var result = new List<Dependency>();

            if (constructor != null) {
                var parameters = constructor.GetParameters().Where(p =>
                    p.ParameterType.IsInterface || this.supportedDependencies.Any(d => d.IsAssignableFrom(p.ParameterType)));
                result.AddRange(parameters.Select(p => new Dependency(p.ParameterType, p.Name)));
            }

            foreach (var dependency in result) {
                dependency.Value = substitutes.FirstOrDefault(s => s.Type == dependency.Type && s.Name == dependency.Name)?.Value;
            }

            return result;
        }


        public List<Dependency> GetDependencies<T>()
        {
            var constructors = typeof(T).GetConstructors();
            var result = new List<Dependency>();
            foreach (var constructor in constructors) {
                var assignableParameters = constructor.GetParameters().Where(p =>
                    p.ParameterType.IsInterface || this.supportedDependencies.Any(d => d.IsAssignableFrom(p.ParameterType))
                );
                foreach (var dependency in assignableParameters) {
                    if (!result.Any(d => d.Type == dependency.ParameterType && d.Name == dependency.Name)) {
                        result.Add(new Dependency(dependency.ParameterType, dependency.Name));
                    }
                }
            }

            return result;
        }


        public Dictionary<Type, object> GetSubstitutes(IEnumerable<Type> dependencies)
        {
            var result = new Dictionary<Type, object>();

            foreach (var dependency in dependencies) {
                var substitute = Substitute.For(new[] {dependency}, Array.Empty<object>());
                result.Add(dependency, substitute);
            }

            return result;
        }
    }
}