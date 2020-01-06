using Catharsium.Util.Testing._Configuration;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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


        public List<Dependency> Dependencies { get; set; }


        public TDependency GetDependency<TDependency>(string name = null)
        {
            var result = this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency) && d.Name == name) ??
                         this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency));
            ;
            if (result != null) {
                return (TDependency)result.Value;
            }

            return default(TDependency);
        }


        public void SetDependency<TDependency>(TDependency dependency, string name = null)
        {
            var dependencyHolder = this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency));
            if (dependencyHolder != null) {
                dependencyHolder.Value = dependency;
            }
            else {
                this.Dependencies.Add(new Dependency(typeof(TDependency), name, dependency));
            }

            this.Target = this.targetFactory.CreateTarget(this.Dependencies);
        }

        #endregion

        #region Construction

        public TestFixture(IDependencyRetriever dependencyRetriever = null, IConstructorFilter constructorFilter = null,
            ITargetFactory<T> targetFactory = null)
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