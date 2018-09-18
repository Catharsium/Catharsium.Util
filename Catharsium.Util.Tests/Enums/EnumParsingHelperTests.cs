using System;
using Catharsium.Util.Enums;
using Catharsium.Util.Tests.Mocks;
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

        #region ParseEnum

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
    }
}
