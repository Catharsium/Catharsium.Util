using Catharsium.Util.Testing._Configuration;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing;

[TestClass]
public class TestFixture<T> where T : class
{
    #region Properties

    protected IDependencyRetriever DependencyRetriever { get; set; }
    protected ITargetFactory<T> TargetFactory { get; set; }
    protected IConstructorFilter ConstructorFilter { get; set; }


    public T Target { get; set; }


    public List<Dependency> Dependencies { get; set; }


    public TDependency GetDependency<TDependency>(string name = null)
    {
        var result = this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency) && d.Name == name) ?? this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency));
        return result != null ? (TDependency)result.Value : default;
    }


    public void SetDependency<TDependency>(TDependency dependency, string name = null)
    {
        var dependencyHolder = this.Dependencies.FirstOrDefault(d => d.Type == typeof(TDependency) && (string.IsNullOrWhiteSpace(name) || d.Name == name));
        if (dependencyHolder != null) {
            dependencyHolder.Value = dependency;
        }
        else {
            this.Dependencies.Add(new Dependency(typeof(TDependency), name, dependency));
        }

        this.Target = this.TargetFactory.CreateTarget(this.Dependencies);
    }

    #endregion

    #region Construction

    public TestFixture(
        IServiceCollection serviceCollection = null,
        IDependencyRetriever dependencyRetriever = null,
        IConstructorFilter constructorFilter = null,
        ITargetFactory<T> targetFactory = null)
    {
        var services = ServiceProviderFactory.Create(serviceCollection ?? new ServiceCollection());
        this.DependencyRetriever = dependencyRetriever ?? services.GetService<IDependencyRetriever>();
        this.ConstructorFilter = constructorFilter ?? services.GetService<IConstructorFilter>();
        this.TargetFactory = targetFactory ?? new TargetFactory<T>(this.ConstructorFilter);
        this.Setup();
    }

    #endregion

    #region Methods

    public void Setup()
    {
        this.Dependencies = this.DependencyRetriever.GetDependencySubstitutes<T>();
        var constructor = this.ConstructorFilter.GetLargestEligibleConstructor(typeof(T));
        var substitutes = this.DependencyRetriever.GetDependencySubstitutes(constructor, this.Dependencies);
        this.Target = this.TargetFactory.CreateTarget(substitutes);
    }

    #endregion
}