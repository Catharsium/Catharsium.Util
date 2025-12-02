using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Catharsium.Util.Testing.Tests.Reflection.DependencyRetrieverTests;

[TestClass]
public class GetDependencySubstitutesForTypeTests
{
    #region Fixture

    private ISubstituteService SubstituteFactory { get; set; }
    private IEnumerable<Type> SupportedTypes { get; set; }
    public DependencyRetriever Target { get; set; }


    [TestInitialize]
    public void Setup() {
        this.SubstituteFactory = Substitute.For<ISubstituteService>();
        this.SupportedTypes = [typeof(Guid)];
        this.Target = new DependencyRetriever(this.SubstituteFactory, this.SupportedTypes);
    }

    #endregion

    #region GetDependencySubstitutes

    [TestMethod]
    public void GetDependencySubstitutes_NoDependencies_ReturnsEmptyList() {
        var actual = this.Target.GetDependencySubstitutes<object>();
        Assert.IsNotNull(actual);
        Assert.IsEmpty(actual);
    }


    [TestMethod]
    public void GetDependencySubstitutes_ConstructorWithAllDependencies_ReturnsAllDependencies() {
        var actual = this.Target.GetDependencySubstitutes<MockObject>();
        Assert.IsNotNull(actual);
        Assert.HasCount(2, actual);
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1) && d.Name == "interface1"));
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2) && d.Name == "interface2"));
    }


    [TestMethod]
    public void GetDependencySubstitutes_SingleConstructors_ReturnsAllDependencies() {
        var actual = this.Target.GetDependencySubstitutes<MockObjectWithSingleConstructor>();
        Assert.IsNotNull(actual);
        Assert.HasCount(2, actual);
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1) && d.Name == "interface1"));
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2) && d.Name == "interface2"));
    }


    [TestMethod]
    public void GetDependencySubstitutes_ConstructorWithoutInterfaceDependencies_ReturnsEmptyList() {
        var actual = this.Target.GetDependencySubstitutes<MockObjectWithoutInterfaces>();
        Assert.IsNotNull(actual);
        Assert.IsEmpty(actual);
    }


    [TestMethod]
    public void GetDependencySubstitutes_MultipleConstructorsWithDifferentDependencies_ReturnsAllDependencies() {
        var actual = this.Target.GetDependencySubstitutes<MockObjectWithDifferentDependencies>();
        Assert.IsNotNull(actual);
        Assert.HasCount(2, actual);
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1) && d.Name == "interface1"));
        Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2) && d.Name == "interface2"));
    }

    #endregion
}