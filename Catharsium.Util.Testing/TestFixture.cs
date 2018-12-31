using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing
{
    [TestClass]
    public class TestFixture<T> where T : class
    {
        #region Properties

        public T Target { get; set; }


        public Dictionary<Type, object> Dependencies { get; set; }

        public TDependency GetDependency<TDependency>() where TDependency : class
        {
            if (!this.Dependencies.ContainsKey(typeof(TDependency))) { return null; }

            return this.Dependencies[typeof(TDependency)] as TDependency;
        }

        #endregion

        #region Construction

        public TestFixture()
        {
            this.Setup();
        }

        #endregion

        #region Methods

        [TestInitialize]
        public void Setup()
        {
            var constructor = this.GetConstructor();
            var parameters = constructor.GetParameters();
            this.Dependencies = new Dictionary<Type, object>();
            var arguments = new List<object>();
            foreach (var parameter in parameters) {
                var dependency = Substitute.For(new[] {parameter.ParameterType}, Array.Empty<object>());
                this.Dependencies.Add(parameter.ParameterType, dependency);
                arguments.Add(dependency);
            }

            this.Target = constructor.Invoke(arguments.ToArray()) as T;
        }


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