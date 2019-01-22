using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing
{
    [TestClass]
    public class TestFixture<T> where T : class
    {
        #region Properties

        private readonly ITargetFactory<T> targetFactory;
        
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

        public TestFixture(ITargetFactory<T> targetFactory = null)
        {
            this.targetFactory = targetFactory ?? new TargetFactory<T>();
            this.Setup();
        }

        #endregion

        #region Methods

        public void Setup()
        {
            var constructor = this.targetFactory.GetLargestEligibleConstructor();
            this.Dependencies = this.targetFactory.GetDependencySubstitutes(constructor);
            this.Target = this.targetFactory.CreateTarget(this.Dependencies);
        }

        #endregion
    }
}