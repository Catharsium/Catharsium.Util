using Catharsium.Util.Enums;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Catharsium.Util.Tests.Enums;

[TestClass]
public class EnumValuesHelperTests
{
    [TestMethod]
    public void GetValues_ReturnsEnumValues() {
        var actual = EnumValuesHelper.GetValues<MockEnumeration>().ToArray();
        Assert.HasCount(4, actual);
        Assert.AreEqual(MockEnumeration.First, actual[0]);
        Assert.AreEqual(MockEnumeration.Second, actual[1]);
        Assert.AreEqual(MockEnumeration.WithAlias, actual[2]);
        Assert.AreEqual(MockEnumeration.WithoutAlias, actual[3]);
    }


    [TestMethod]
    public void GetValues_NotAnEnum_ThrowsException() {
        Assert.Throws<ArgumentException>(EnumValuesHelper.GetValues<int>);
    }
}