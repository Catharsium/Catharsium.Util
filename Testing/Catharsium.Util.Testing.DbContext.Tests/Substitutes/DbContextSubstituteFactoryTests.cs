﻿using Catharsium.Util.Testing.DbContext.Substitutes;
using Catharsium.Util.Testing.DbContext.Tests.Mocks;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.DbContext.Tests.Substitutes;

[TestClass]
public class DbContextSubstituteFactoryTests
{
    #region Fixture

    private IConstructorFilter ConstructorFilter { get; set; }
    protected DbContextSubstituteFactory<MockDbContextWithOptions> Target { get; set; }


    [TestInitialize]
    public void Setup() {
        this.ConstructorFilter = Substitute.For<IConstructorFilter>();
        this.Target = new DbContextSubstituteFactory<MockDbContextWithOptions>(this.ConstructorFilter);
    }

    #endregion

    #region CanCreateFor

    [TestMethod]
    public void CanCreateFor_DbContextType_ReturnsTrue() {
        var type = typeof(MockDbContextWithOptions);
        this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns(type.GetConstructors());

        var actual = this.Target.CanCreateFor(type);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void CanCreateFor_NoDbContextType_ReturnsFalse() {
        var type = typeof(string);
        var actual = this.Target.CanCreateFor(type);
        Assert.IsFalse(actual);
    }

    #endregion

    #region CreateDbContextSubstitute

    [TestMethod]
    public void CreateDbContextSubstitute_NoOptions_ReturnsInstance() {
        var type = typeof(MockDbContextNoOptions);
        this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns([type.GetConstructors().First()]);
        var actual = this.Target.CreateSubstitute(type);
        Assert.IsNotNull(actual);
        Assert.AreEqual(typeof(MockDbContextNoOptions), actual.GetType());
    }


    [TestMethod]
    public void CreateDbContextSubstitute_WithOptions_ReturnsInstance() {
        var type = typeof(MockDbContextWithOptions);
        this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns([type.GetConstructors().First()]);
        var actual = this.Target.CreateSubstitute(type);
        Assert.IsNotNull(actual);
        Assert.AreEqual(typeof(MockDbContextWithOptions), actual.GetType());
    }

    #endregion
}