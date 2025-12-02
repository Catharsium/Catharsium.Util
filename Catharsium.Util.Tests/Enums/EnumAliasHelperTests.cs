using Catharsium.Util.Enums;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Enums;

[TestClass]
public class EnumAliasHelperTests
{
    [TestMethod]
    public void ParseTo_NonEnumType_ThrowsException() {
        Assert.Throws<ArgumentException>(() => "1".ParseTo<int>());
    }


    [TestMethod]
    public void ParseTo_NullAlias_ThrowsException() {
        Assert.Throws<ArgumentNullException>(() => (null as string).ParseTo<MockEnumeration>());
    }


    [TestMethod]
    public void ParseTo_ValidAlias_ReturnsEnumValue() {
        var actual = "1".ParseTo<MockEnumeration>();
        Assert.AreEqual(MockEnumeration.First, actual);
    }


    [TestMethod]
    public void ParseTo_ValidAlias_ReturnsCorrectValue() {
        var actual = "2".ParseTo<MockEnumeration>();
        Assert.AreEqual(MockEnumeration.Second, actual);
    }


    [TestMethod]
    public void ParseTo_InvalidAlias_ThrowsException() {
        var actual = "Other alias".ParseTo<MockEnumeration>();
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void ParseTo_Fallback_DoesNotOverruleAlias() {
        var actual = "2".ParseTo<MockEnumeration>("1");
        Assert.AreEqual(MockEnumeration.Second, actual);
    }


    [TestMethod]
    public void ParseTo_InvalidAlias_UsesFallback() {
        var actual = "Other alias".ParseTo<MockEnumeration>("2");
        Assert.AreEqual(MockEnumeration.Second, actual);
    }
}