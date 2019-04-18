using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing
{
    [TestClass]
    public class TestFixture<T> where T : class
    {
        #region Properties

        private readonly IDependencyRetriever dependencyRetriever;
        private readonly ITargetFactory<T> targetFactory;
        private readonly IConstructorFilter<T> constructorFilter;


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
            this.Target = this.targetFactory.CreateTarget(this.Dependencies);
        }

        #endregion

        #region Construction

        public TestFixture(IDependencyRetriever dependencyRetriever = null, IConstructorFilter<T> constructorFilter = null, ITargetFactory < T> targetFactory = null)
        {
            this.dependencyRetriever = dependencyRetriever ?? new DependencyRetriever();
            this.constructorFilter = constructorFilter ?? new ConstructorFilter<T>();
            this.targetFactory = targetFactory ?? new TargetFactory<T>(this.constructorFilter);
            this.Setup();
        }

        #endregion

        #region Methods

        public void Setup()
        {
            this.Dependencies = this.dependencyRetriever.GetDependencySubstitutes<T>();
            var constructor = this.constructorFilter.GetLargestEligibleConstructor();
            var substitutes = this.dependencyRetriever.GetDependencySubstitutes(constructor, this.Dependencies);
            this.Target = this.targetFactory.CreateTarget(substitutes);
        }

        #endregion
    }
}