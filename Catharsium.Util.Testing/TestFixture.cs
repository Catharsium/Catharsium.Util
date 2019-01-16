using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing
{
    [TestClass]
    public class TestFixture<T> where T : class
    {
        #region Properties

        private readonly TargetFactory<T> TargetFactory;

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
            this.Target = this.TargetFactory.CreateTarget(this.Dependencies);
        }

        #endregion

        #region Construction

        public TestFixture()
        {
            this.TargetFactory = new TargetFactory<T>();
            this.Setup();
        }

        #endregion

        #region Methods

        [TestInitialize]
        public void Setup()
        {
            this.Dependencies = new Dictionary<Type, object>();

            var constructor = this.TargetFactory.GetLargestEligibleConstructor(this.Dependencies);
            var parameters = constructor.GetParameters();
            foreach (var parameter in parameters)
            {
                var dependency = Substitute.For(new[] { parameter.ParameterType }, Array.Empty<object>());
                this.Dependencies.Add(parameter.ParameterType, dependency);
            }

            this.Target = this.TargetFactory.CreateTarget(this.Dependencies);
        }

        #endregion
    }
}