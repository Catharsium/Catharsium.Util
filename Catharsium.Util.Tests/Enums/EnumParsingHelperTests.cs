using Catharsium.Util.Enums;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Catharsium.Util.Tests.Enums;

[TestClass]
public class EnumParsingHelperTests
{
    #region ParseNullableEnum

    [TestMethod]
    public void ParseNullableEnum_ValidValue_ReturnsEnumValue()
    {
        var expected = MockEnumeration.Second;
        var actual = expected.ToString().ParseNullableEnum<MockEnumeration>(false);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void ParseNullableEnum_EmptyValueNotRequired_ReturnsNull()
    {
        var expected = "";
        var actual = expected.ParseNullableEnum<MockEnumeration>(false);
        Assert.AreEqual(null, actual);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ParseNullableEnum_EmptyValueButRequired_ThrowsException()
    {
        var expected = "";
        expected.ParseNullableEnum<MockEnumeration>(true);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParseNullableEnum_InvalidValue_ThrowsException()
    {
        var expected = "Some value";
        expected.ParseNullableEnum<MockEnumeration>(false);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParseNullableEnum_NoEnumType_ThrowsException()
    {
        var expected = MockEnumeration.Second;
        expected.ToString().ParseNullableEnum<int>(false);
    }

    #endregion

    #region ParseEnum(value)

    [TestMethod]
    public void ParseEnum_ValidValue_ReturnsEnumValue()
    {
        var expected = MockEnumeration.Second;
        var actual = expected.ToString().ParseEnum<MockEnumeration>();
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ParseEnum_EmptyValue_ThrowsException()
    {
        var expected = "";
        expected.ParseEnum<MockEnumeration>();
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParseEnum_InvalidValue_ThrowsException()
    {
        var expected = "Other value";
        expected.ParseEnum<MockEnumeration>();
    }

    #endregion

    #region ParseEnum(value, defaultValue)

    [TestMethod]
    public void ToEnum_ValidInput_ReturnsInputAsEnum()
    {
        var input = MockEnumeration.First;
        var actual = input.ToString().ParseEnum(MockEnumeration.First);
        Assert.AreEqual(MockEnumeration.First, actual);
    }


    [TestMethod]
    public void ToEnum_InvalidInput_ReturnsFallback()
    {
        var defaultValue = MockEnumeration.Second;
        var actual = "Not a value".ParseEnum(defaultValue);
        Assert.AreEqual(defaultValue, actual);
    }

    #endregion
}