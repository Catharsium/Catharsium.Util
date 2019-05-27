using System;
using System.Collections.Generic;
using Catharsium.Util.Testing._Configuration;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing
{
    [TestClass]
    public class TestFixture<T> where T : class
    {
        #region Properties

        private readonly IDependencyRetriever dependencyRetriever;
        private readonly ITargetFactory<T> targetFactory;
        private readonly IConstructorFilter constructorFilter;


        public T Target { get; set; }


        public Dictionary<Type, object> Dependencies { get; set; }


        public TDependency GetDependency<TDependency>()
        {
            return this.Dependencies.ContainsKey(typeof(TDependency)) ?
                (TDependency)this.Dependencies[typeof(TDependency)] :
                default;
        }


        public void SetDependency<TDependency>(TDependency dependency)
        {
            this.Dependencies[typeof(TDependency)] = dependency;
            this.Target = this.targetFactory.CreateTarget(this.Dependencies);
        }

        #endregion

        #region Construction

        public TestFixture(IDependencyRetriever dependencyRetriever = null, IConstructorFilter constructorFilter = null, ITargetFactory<T> targetFactory = null)
        {
            var services = ServiceProviderFactory.Create();
            this.dependencyRetriever = dependencyRetriever ?? services.GetService<IDependencyRetriever>();
            this.constructorFilter = constructorFilter ?? services.GetService<IConstructorFilter>();
            this.targetFactory = targetFactory ?? new TargetFactory<T>(this.constructorFilter);
            this.Setup();
        }

        #endregion

        #region Methods

        public void Setup()
        {
            this.Dependencies = this.dependencyRetriever.GetDependencySubstitutes<T>();
            var constructor = this.constructorFilter.GetLargestEligibleConstructor(typeof(T));
            var substitutes = this.dependencyRetriever.GetDependencySubstitutes(constructor, this.Dependencies);
            this.Target = this.targetFactory.CreateTarget(substitutes);
        }

        #endregion
    }
}