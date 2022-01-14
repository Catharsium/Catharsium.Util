using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
namespace Catharsium.Util.Testing.Tests.Reflection.ConstructorFilterTests;

[TestClass]
public class GetLargestEligibleConstructorTests
{
    #region Fixture

    private Type Type { get; set; }

    private List<Dependency> Dependencies { get; set; }

    private ConstructorFilter Target { get; set; }


    [TestInitialize]
    public void Setup()
    {
        this.Type = typeof(MockObject);
        this.Dependencies = new List<Dependency>();
        this.Target = new ConstructorFilter(Array.Empty<Type>());
    }

    #endregion

    #region GetLargestEligibleConstructor

    [TestMethod]
    public void GetLargestEligibleConstructor_NoDependencies_ReturnsLargestConstructorWithOnlyInterfaces()
    {
        var actual = this.Target.GetLargestEligibleConstructor(this.Type, this.Dependencies);
        Assert.AreEqual(2, actual.GetParameters().Length);
    }


    [TestMethod]
    public void GetLargestEligibleConstructor_WithDependenciesFromLargestConstructor_ReturnsLargestConstructor()
    {
        this.Dependencies.Add(new Dependency(typeof(IMockInterface1), "interface1", Substitute.For<IMockInterface1>()));
        this.Dependencies.Add(new Dependency(typeof(IMockInterface2), "interface2", Substitute.For<IMockInterface2>()));
        this.Dependencies.Add(new Dependency(typeof(string), "stringDependency", "My string"));

        var actual = this.Target.GetLargestEligibleConstructor(this.Type, this.Dependencies);
        Assert.AreEqual(3, actual.GetParameters().Length);
    }

    #endregion
}