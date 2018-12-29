using System;
using System.Collections.Generic;
using NSubstitute;

namespace Catharsium.Util.Tests.Testing
{
    public class TestClass<T> where T : class
    {
        protected T Target { get; set; }

        protected Dictionary<Type, object> Dependencies { get; set; }


        public TestClass()
        {
            var type = typeof(T);
            var constructors = type.GetConstructors();
            var parameters = constructors[0].GetParameters();
            var arguments = new List<object>();
            this.Dependencies = new Dictionary<Type, object>();
            foreach (var parameter in parameters)
            {
                var dependency = Substitute.For(new[] { parameter.ParameterType }, Array.Empty<object>());
                this.Dependencies.Add(parameter.ParameterType, dependency);
                arguments.Add(dependency);
            }
            this.Target = constructors[0].Invoke(arguments.ToArray()) as T;
        }


        protected Tdep GetDependency<Tdep>() where Tdep : class
        {

            return this.Dependencies[typeof(Tdep)] as Tdep;
        }
    }
}