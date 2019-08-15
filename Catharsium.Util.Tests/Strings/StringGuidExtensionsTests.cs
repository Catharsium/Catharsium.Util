using System;
using Catharsium.Util.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Strings
{
    [TestClass]
    public class StringGuidExtensionsTests
    {
        #region ToGuid

        [TestMethod]
        public void ToGuid_NullInput_ReturnsDefault()
        {
            var actual = ((string)null).ToGuid();
            Assert.AreEqual(default(Guid), actual);
        }


        [TestMethod]
        public void ToGuid_InvalidGuid_ReturnsDefault()
        {
            var expected = new Guid();
            var actual = (expected + "1").ToGuid();
            Assert.AreEqual(default(Guid), actual);
        }


        [TestMethod]
        public void ToGuid_ValidGuid_ReturnsExpected()
        {
            var expected = new Guid();
            var actual = expected.ToString().ToGuid();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region IsGuid

        [TestMethod]
        public void IsGuid_ValidGuid_ReturnsTrue()
        {
            var actual = Guid.NewGuid().ToString().IsGuid();
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsGuid_InvalidGuid_ReturnsFalse()
        {
            var actual = "Not a guid".IsGuid();
            Assert.IsFalse(actual);
        }

        #endregion
    }
}