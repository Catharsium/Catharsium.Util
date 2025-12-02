using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing.Tests.Reflection;

[TestClass]
public class TargetFactoryTests
{
    #region Fixture

    private Type Type { get; set; }
    private List<Dependency> Dependencies { get; set; }
    protected IConstructorFilter ConstructorFilter { get; set; }
    protected TargetFactory<MockObject> Target { get; set; }


    [TestInitialize]
    public void Setup() {
        this.Type = typeof(MockObject);
        this.Dependencies = [];
        this.ConstructorFilter = Substitute.For<IConstructorFilter>();
        this.Target = new TargetFactory<MockObject>(this.ConstructorFilter);
    }

    #endregion

    #region CreateTarget

    [TestMethod]
    public void CreateTarget_WithAllInterfaceDependencies_ReturnsTargetWithInterfacesFilled() {
        var dependency1Type = typeof(IMockInterface1);
        var dependency2Type = typeof(IMockInterface2);
        this.Dependencies.Add(new Dependency(dependency1Type, "interface1", Substitute.For<IMockInterface1>()));
        this.Dependencies.Add(new Dependency(dependency2Type, "interface2", Substitute.For<IMockInterface2>()));
        var constructor = this.Type.GetConstructor([dependency1Type, dependency2Type]);
        this.ConstructorFilter.GetLargestEligibleConstructor(this.Type, this.Dependencies).Returns(constructor);

        var actual = this.Target.CreateTarget(this.Dependencies);
        Assert.IsNotNull(actual);
        Assert.IsNotNull(actual.InterfaceDependency1);
        Assert.IsNotNull(actual.InterfaceDependency2);
        Assert.IsNull(actual.StringDependency);
    }


    [TestMethod]
    public void CreateTarget_WithTooFewDependencies_ReturnsNull() {
        this.Dependencies.Add(new Dependency(typeof(IMockInterface2), "interface2", Substitute.For<IMockInterface2>()));
        var constructor = this.Type.GetConstructor([typeof(IMockInterface1), typeof(IMockInterface2)]);
        this.ConstructorFilter.GetLargestEligibleConstructor(this.Type).Returns(constructor);

        var actual = this.Target.CreateTarget(this.Dependencies);
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void CreateTarget_WithTooManyDependencies_ReturnsTargetWithInterfacesFilled() {
        var dependency1Type = typeof(IMockInterface1);
        var dependency2Type = typeof(IMockInterface2);
        this.Dependencies.Add(new Dependency(dependency1Type, "interface1", Substitute.For<IMockInterface1>()));
        this.Dependencies.Add(new Dependency(dependency2Type, "interface2", Substitute.For<IMockInterface2>()));
        var constructor = this.Type.GetConstructor([dependency1Type]);
        this.ConstructorFilter.GetLargestEligibleConstructor(this.Type, this.Dependencies).Returns(constructor);

        var actual = this.Target.CreateTarget(this.Dependencies);
        Assert.IsNotNull(actual);
        Assert.IsNotNull(actual.InterfaceDependency1);
        Assert.IsNull(actual.InterfaceDependency2);
        Assert.IsNull(actual.StringDependency);
    }


    [TestMethod]
    public void CreateTarget_NoDependencies_ReturnsNull() {
        var actual = this.Target.CreateTarget(this.Dependencies);
        Assert.IsNull(actual);
    }

    #endregion
}