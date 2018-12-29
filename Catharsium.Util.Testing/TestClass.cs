using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute;

namespace Catharsium.Util.Tests.Testing
{
    public class TestClass<T> where T : class
    {
        #region Properties

        public T Target { get; set; }


        public Dictionary<Type, object> Dependencies { get; set; }

        public Tdependency GetDependency<Tdependency>() where Tdependency : class
        {
            return this.Dependencies[typeof(Tdependency)] as Tdependency;
        }

        #endregion

        #region Construction

        public TestClass()
        {
            var constructor = this.GetConstructor();
            var parameters = constructor.GetParameters();
            this.Dependencies = new Dictionary<Type, object>();
            var arguments = new List<object>();
            foreach (var parameter in parameters)
            {
                var dependency = Substitute.For(new[] { parameter.ParameterType }, Array.Empty<object>());
                this.Dependencies.Add(parameter.ParameterType, dependency);
                arguments.Add(dependency);
            }
            this.Target = constructor.Invoke(arguments.ToArray()) as T;
        }

        #endregion

        #region Methods

        public ConstructorInfo GetConstructor()
        {
            var constructors = typeof(T).GetConstructors();
            return constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface))
                               .OrderBy(c => c.GetParameters().Length)
                               .LastOrDefault();
        }

        #endregion
    }
}