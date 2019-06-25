using Catharsium.Util.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Strings
{
    [TestClass]
    public class StringDateExtensionsTests
    {
        [TestMethod]
        public void ToDate_NullInput_ReturnsDefault()
        {
            var actual = (null as string).ToDate();
            Assert.AreEqual(default(DateTime), actual);
        }


        [TestMethod]
        public void ToDate_yyyyMMddInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = expected.ToString("yyyyMMdd").ToDate();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyyMMddHHmmssInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = expected.ToString("yyyyMMddHHmmss").ToDate();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyy_MM_ddInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = expected.ToString("yyyy-MM-dd").ToDate();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyy_MM_dd_HH_mm_ssInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = expected.ToString("yyyy-MM-dd HH:mm:ss").ToDate();
            Assert.AreEqual(expected, actual);
        }
    }
}