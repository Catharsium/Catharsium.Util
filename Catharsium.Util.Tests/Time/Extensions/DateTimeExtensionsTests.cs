using Catharsium.Util.Time.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Time.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetWeekOfYear_FirstDayOfYear_Returns1()
        {
            var date = new DateTime(2020, 1, 1);
            var actual = date.GetWeekOfYear();
            Assert.AreEqual(1, actual);
        }


        [TestMethod]
        public void GetWeekOfYear_SpecificDay_ReturnsWeekNumber()
        {
            var date = new DateTime(2020, 11, 10);
            var actual = date.GetWeekOfYear();
            Assert.AreEqual(46, actual);
        }


        [TestMethod]
        public void GetWeekOfYear_LastDayOfYear_ReturnsLastWeekNumber()
        {
            var date = new DateTime(2020, 12, 31);
            var actual = date.GetWeekOfYear();
            Assert.AreEqual(53, actual);
        }
    }
}