﻿using Catharsium.Util.Reflection.Attributes;
using Catharsium.Util.Reflection.Attributes.Extensions;
using Catharsium.Util.Tests._Mocks;
using Catharsium.Util.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Catharsium.Util.Tests.Reflection.Attributes.Extensions;

[TestClass]
public class GetAttributeExtensionsTests
{
    #region GetAttribute<T>(subject)

    [TestMethod]
    public void GetAttribute_InstanceWithRequestedAttribute_ReturnsAttribute() {
        var subject = new MockObjectWithDisplayAttribute();
        var actual = subject.GetAttribute<DisplayAttribute>();
        Assert.IsNotNull(actual);
        Assert.AreEqual("My class name", actual.Name);
    }


    [TestMethod]
    public void GetAttribute_InstanceWithoutRequestedAttribute_ReturnsNull() {
        var subject = new GetAttributeExtensionsTests();
        var actual = subject.GetAttribute<DisplayAttribute>();
        Assert.IsNull(actual);
    }

    #endregion

    #region GetAttribute<T>(subject, memberName)

    [TestMethod]
    public void GetAttribute_PropertyWithRequestedAttribute_ReturnsAttribute() {
        var subject = new MockObjectWithDisplayAttribute();
        var actual = subject.GetAttribute<DisplayAttribute>(nameof(subject.PropertyWithDisplayAttribute));
        Assert.IsNotNull(actual);
        Assert.AreEqual("My property name", actual.Name);
    }


    [TestMethod]
    public void GetAttribute_PropertyWithDifferentAttribute_ReturnsNull() {
        var subject = new MockObjectWithDisplayAttribute();
        var actual = subject.GetAttribute<BsnAttribute>(nameof(subject.PropertyWithoutAttributes));
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void GetAttribute_PropertyWithoutRequestedAttribute_ReturnsNull() {
        var subject = new MockObjectWithDisplayAttribute();
        var actual = subject.GetAttribute<DisplayAttribute>(nameof(subject.PropertyWithoutAttributes));
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void GetAttribute_MethodWithAttribute_ReturnsAttribute() {
        var subject = new MockMethod();
        var actual = subject.GetAttribute<AliasAttribute>("MethodWithAlias");
        Assert.IsNotNull(actual);
    }


    [TestMethod]
    public void GetAttribute_MethodWithDifferentAttribute_ReturnsNull() {
        var subject = new MockMethod();
        var actual = subject.GetAttribute<DisplayAttribute>("MethodWithAlias");
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void GetAttribute_MethodWithoutRequestedAttribute_ReturnsNull() {
        var subject = new MockMethod();
        var actual = subject.GetAttribute<AliasAttribute>("MethodWithoutAlias");
        Assert.IsNull(actual);
    }

    #endregion

    #region GetMemberAttribute<T>(subject)

    [TestMethod]
    public void GetAttributeValue_WithAttribute_ReturnsAttribute() {
        var actual = MockEnumeration.WithAlias.GetMemberAttribute<AliasAttribute>();
        Assert.IsNotNull(actual);
        Assert.IsTrue(actual.Aliases.Any(a => a == "My alias"));
    }


    [TestMethod]
    public void GetAttributeValue_WithoutAttribute_ReturnsNull() {
        var actual = MockEnumeration.WithoutAlias.GetMemberAttribute<AliasAttribute>();
        Assert.IsNull(actual);
    }

    #endregion
}