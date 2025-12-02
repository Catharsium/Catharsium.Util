using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.Tests.TestFixtureTests;

[TestClass]
public class TestFixtureIntegrationTests
{
    #region Constructor

    [TestMethod]
    public void TestFixture_WorksWith_ALargestSatisfiableConstructor() {
        var actual = new TestFixture<MockObject>();
        Assert.IsNotNull(actual.Target);
        Assert.IsNotNull(actual.Dependencies);
        Assert.HasCount(2, actual.Dependencies);
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
        Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
    }


    [TestMethod]
    public void TestFixture_WorksWith_SingleConstructor() {
        var actual = new TestFixture<MockObjectWithSingleConstructor>();
        Assert.IsNull(actual.Target);
        Assert.IsNotNull(actual.Dependencies);
        Assert.HasCount(2, actual.Dependencies);
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
    }


    [TestMethod]
    public void TestFixture_WorksWith_ConstructorWithoutInterfacesDependencies() {
        var actual = new TestFixture<MockObjectWithoutInterfaces>();
        Assert.IsNull(actual.Target);
        Assert.IsNotNull(actual.Dependencies);
        Assert.IsEmpty(actual.Dependencies);
    }


    [TestMethod]
    public void TestFixture_WorksWith_ConstructorsDifferentDependencies() {
        var actual = new TestFixture<MockObjectWithDifferentDependencies>();
        Assert.IsNotNull(actual.Target);
        Assert.IsNotNull(actual.Target.InterfaceDependency1);
        Assert.IsNull(actual.Target.InterfaceDependency2);
        Assert.IsNull(actual.Target.StringDependency);
        Assert.IsNotNull(actual.Dependencies);
        Assert.HasCount(2, actual.Dependencies);
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
        Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
    }


    [TestMethod]
    public void TestFixture_WorksWith_AllSupportedDependencies() {
        var actual = new TestFixture<MockObjectWithAllSupportedDependencies>();
        Assert.IsNotNull(actual.Target);
        Assert.IsNull(actual.Target.InterfaceDependency1);
        Assert.IsNotNull(actual.Target.InterfaceDependency2);
        Assert.IsNotNull(actual.Dependencies);
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
        Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
        Assert.IsTrue(Contains(actual.Dependencies, typeof(Guid)));
        Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
    }

    #endregion

    private static bool Contains(IEnumerable<Dependency> dependencies, Type type, string name = null, object value = null) {
        var dependency = dependencies.FirstOrDefault(d => d.Type == type && (name == null || d.Name == name));
        return dependency != null
            && (value != null ? dependency.Value == value : dependency.Value != null);
    }
}