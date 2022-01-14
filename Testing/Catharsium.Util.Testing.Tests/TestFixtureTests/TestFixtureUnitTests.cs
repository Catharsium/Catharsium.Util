using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace Catharsium.Util.Testing.Tests.TestFixtureTests;

[TestClass]
public class TestFixtureUnitTests
{
    #region Fixture

    private Type Type { get; set; }
    private List<Dependency> ExpectedDependencies { get; set; }
    private MockObject ExpectedTarget { get; set; }

    private IServiceCollection ServiceCollection { get; set; }
    private IDependencyRetriever DependencyRetriever { get; set; }
    private IConstructorFilter ConstructorFilter { get; set; }
    private ITargetFactory<MockObject> TargetFactory { get; set; }
    private TestFixture<MockObject> Target { get; set; }


    [TestInitialize]
    public void Setup()
    {
        this.Type = typeof(MockObject);

        this.ExpectedDependencies = new List<Dependency>();
        this.ExpectedTarget = new MockObject(null);

        this.ServiceCollection = Substitute.For<IServiceCollection>();
        this.DependencyRetriever = Substitute.For<IDependencyRetriever>();
        var constructorInfo = Substitute.For<ConstructorInfo>();
        this.DependencyRetriever.GetDependencySubstitutes<MockObject>().Returns(this.ExpectedDependencies);
        this.DependencyRetriever.GetDependencySubstitutes(constructorInfo, this.ExpectedDependencies).Returns(this.ExpectedDependencies);

        this.TargetFactory = Substitute.For<ITargetFactory<MockObject>>();
        this.ConstructorFilter = Substitute.For<IConstructorFilter>();
        this.ConstructorFilter.GetLargestEligibleConstructor(this.Type).Returns(constructorInfo);
        this.TargetFactory.CreateTarget(this.ExpectedDependencies).Returns(this.ExpectedTarget);
        this.Target = new TestFixture<MockObject>(this.ServiceCollection, this.DependencyRetriever, this.ConstructorFilter, this.TargetFactory);
    }

    #endregion

    #region Constructor

    [TestMethod]
    public void Constructor_StoresDependencies()
    {
        var actual = new TestFixture<MockObject>(this.ServiceCollection, this.DependencyRetriever, this.ConstructorFilter, this.TargetFactory);
        Assert.IsNotNull(actual.Dependencies);
        Assert.AreEqual(this.ExpectedDependencies, actual.Dependencies);
    }


    [TestMethod]
    public void Constructor_ObtainsInitialConstructor_CreatesTarget()
    {
        var actual = new TestFixture<MockObject>(this.ServiceCollection, this.DependencyRetriever, this.ConstructorFilter, this.TargetFactory);
        Assert.IsNotNull(actual.Target);
        Assert.AreEqual(this.ExpectedTarget, actual.Target);
    }

    #endregion

    #region GetDependency

    [TestMethod]
    public void GetDependency_ValidType_ReturnsDependency()
    {
        var expected = "";
        this.Target.Dependencies.Add(new Dependency(typeof(string), "stringDependency", expected));

        var actual = this.Target.GetDependency<string>();
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void GetDependency_InvalidType_ReturnsNull()
    {
        var actual = this.Target.GetDependency<string>();
        Assert.IsNull(actual);
    }

    #endregion

    #region SetDependency

    [TestMethod]
    public void SetDependency_NewDependency_IsAddedToDependenciesList()
    {
        var name = "My name";
        var expected = "My string";
        this.ExpectedDependencies.Add(new Dependency(typeof(string), name, expected));
        this.TargetFactory.CreateTarget(this.ExpectedDependencies).Returns(this.ExpectedTarget);
        this.Target = new TestFixture<MockObject>(this.ServiceCollection, this.DependencyRetriever, this.ConstructorFilter, this.TargetFactory);

        this.Target.SetDependency(expected);
        Assert.IsTrue(this.Target.Dependencies.Any(d => d.Type == expected.GetType() && d.Name == name));
        Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
    }


    [TestMethod]
    public void SetDependency_ExistingDependency_ReplacesCurrentInDependenciesList()
    {
        var expected = Substitute.For<IMockInterface1>();
        var type = typeof(IMockInterface1);
        this.Target.Dependencies.Add(new Dependency(typeof(IMockInterface1), ""));

        this.Target.SetDependency(expected);
        Assert.IsTrue(this.Target.Dependencies.Any(d => d.Type == type && d.Value == expected));
        Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
    }


    [TestMethod]
    public void SetDependency_DependencyInMostSpecificConstructor_NewTargetWithDependencyAndAllInterfacesSatisfied()
    {
        var expected = "My string";
        this.Target.SetDependency(expected);
        Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
    }

    #endregion
}