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
            return this.Dependencies.ContainsKey(typeof(TDependency)) ?
                this.Dependencies[typeof(TDependency)] as TDependency :
                null;
        }


        public void SetDependency<TDependency>(TDependency dependency)
        {
            this.Dependencies[typeof(TDependency)] = dependency;
            this.InitializeTarget();
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
            this.Dependencies = new Dictionary<Type, object>();

            var constructor = this.GetLargestEligibleConstructor();
            var parameters = constructor.GetParameters();
            foreach (var parameter in parameters)
            {
                var dependency = Substitute.For(new[] { parameter.ParameterType }, Array.Empty<object>());
                this.Dependencies.Add(parameter.ParameterType, dependency);
            }

            this.InitializeTarget();
        }


        public void InitializeTarget()
        {
            var constructor = this.GetLargestEligibleConstructor();
            var parameters = constructor.GetParameters();
            var arguments = new List<object>();
            foreach (var parameter in parameters)
            {
                arguments.Add(this.Dependencies[parameter.ParameterType]);
            }

            this.Target = constructor.Invoke(arguments.ToArray()) as T;
        }


        public ConstructorInfo GetLargestEligibleConstructor()
        {
            return this.GetEligibleConstructors().OrderBy(c => c.GetParameters().Length)
                                                 .LastOrDefault();
        }


        public IEnumerable<ConstructorInfo> GetEligibleConstructors()
        {
            var constructors = typeof(T).GetConstructors();
            return constructors.Where(c => c.GetParameters().All(p => p.ParameterType.IsInterface || this.Dependencies.ContainsKey(p.ParameterType)));
        }

        #endregion
    }
}