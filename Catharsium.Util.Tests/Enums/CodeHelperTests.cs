using Catharsium.Util.Enums;
using Catharsium.Util.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Enums
{
    [TestClass]
    public class CodeHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTo_NonEnumType_ThrowsException()
        {
            "1".ParseTo<int>();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseTo_NullCode_ThrowsException()
        {
            (null as string).ParseTo<MockEnum>();
        }


        [TestMethod]
        public void ParseTo_ValidCode_ReturnsEnumValue()
        {
            var actual = "1".ParseTo<MockEnum>();
            Assert.AreEqual(MockEnum.First, actual);
        }


        [TestMethod]
        public void ParseTo_ValidCode_ReturnsCorrectValue()
        {
            var actual = "2".ParseTo<MockEnum>();
            Assert.AreEqual(MockEnum.Second, actual);
        }


        [TestMethod]
        public void ParseTo_InvalidCode_ThrowsException()
        {
            var actual = "Other code".ParseTo<MockEnum>();
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void ParseTo_Fallback_DoesNotOverruleCode()
        {
            var actual = "2".ParseTo<MockEnum>("1");
            Assert.AreEqual(MockEnum.Second, actual);
        }


        [TestMethod]
        public void ParseTo_InvalidCode_UsesFallback()
        {
            var actual = "Other code".ParseTo<MockEnum>("2");
            Assert.AreEqual(MockEnum.Second, actual);
        }
    }
}