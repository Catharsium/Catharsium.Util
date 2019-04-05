using System;
using Catharsium.Util.Enums;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Enums
{
    [TestClass]
    public class EnumParsingHelperTests
    {
        #region ParseNullableEnum

        [TestMethod]
        public void ParseNullableEnum_ValidValue_ReturnsEnumValue()
        {
            var expected = MockEnum.Second;
            var actual = expected.ToString().ParseNullableEnum<MockEnum>(false);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ParseNullableEnum_EmptyValueNotRequired_ReturnsNull()
        {
            var expected = "";
            var actual = expected.ParseNullableEnum<MockEnum>(false);
            Assert.AreEqual(null, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseNullableEnum_EmptyValueButRequired_ThrowsException()
        {
            var expected = "";
            expected.ParseNullableEnum<MockEnum>(true);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseNullableEnum_InvalidValue_ThrowsException()
        {
            var expected = "Some value";
            expected.ParseNullableEnum<MockEnum>(false);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseNullableEnum_NoEnumType_ThrowsException()
        {
            var expected = MockEnum.Second;
            expected.ToString().ParseNullableEnum<int>(false);
        }

        #endregion

        #region ParseEnum(value)

        [TestMethod]
        public void ParseEnum_ValidValue_ReturnsEnumValue()
        {
            var expected = MockEnum.Second;
            var actual = expected.ToString().ParseEnum<MockEnum>();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseEnum_EmptyValue_ThrowsException()
        {
            var expected = "";
            expected.ParseEnum<MockEnum>();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseEnum_InvalidValue_ThrowsException()
        {
            var expected = "Other value";
            expected.ParseEnum<MockEnum>();
        }

        #endregion

        #region ParseEnum(value, defaultValue)

        [TestMethod]
        public void ToEnum_ValidInput_ReturnsInputAsEnum()
        {
            var input = MockEnum.First;
            var actual = input.ToString().ParseEnum(MockEnum.First);
            Assert.AreEqual(MockEnum.First, actual);
        }


        [TestMethod]
        public void ToEnum_InvalidInput_ReturnsFallback()
        {
            var defaultValue = MockEnum.Second;
            var actual = "Not a value".ParseEnum(defaultValue);
            Assert.AreEqual(defaultValue, actual);
        }

        #endregion
    }
}