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

        private readonly ITargetFactory<T> TargetFactory;
        
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

        public TestFixture(ITargetFactory<T> targetFactory = null)
        {
            this.TargetFactory = targetFactory;
            if (this.TargetFactory == null)
            {
                this.TargetFactory = new TargetFactory<T>();
            }
            this.Setup();
        }

        #endregion

        #region Methods

        public void Setup()
        {
            var constructor = this.TargetFactory.GetLargestEligibleConstructor();
            this.Dependencies = this.TargetFactory.GetDependencySubstitutes(constructor);
            this.Target = this.TargetFactory.CreateTarget(this.Dependencies);
        }

        #endregion
    }
}