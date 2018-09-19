using Catharsium.Util.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Strings
{
    [TestClass]
    public class StringDateHelperTests
    {
        [TestMethod]
        public void ToDate_NullInput_ReturnsDefault()
        {
            var actual = StringDateHelper.ToDate(null as string);
            Assert.AreEqual(default(DateTime), actual);
        }


        [TestMethod]
        public void ToDate_yyyyMMddInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = StringDateHelper.ToDate(expected.ToString("yyyyMMdd"));
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyyMMddHHmmssInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = StringDateHelper.ToDate(expected.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyy_MM_ddInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = StringDateHelper.ToDate(expected.ToString("yyyy-MM-dd"));
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ToDate_yyyy_MM_dd_HH_mm_ssInput_ReturnsExpected()
        {
            var expected = DateTime.Now.Date;
            var actual = StringDateHelper.ToDate(expected.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(expected, actual);
        }
    }
}