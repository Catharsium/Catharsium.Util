using Catharsium.Util.Time.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Catharsium.Util.Tests.Time.Extensions;

[TestClass]
public class DateTimeExtensionsTests
{
    #region GetWeekOfYear

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

    #endregion

    #region GetDayOfWeek

    [TestMethod]
    public void GetDayOfWeek_WeekStartsSunday_ReturnsSundayBeforeDate()
    {
        var date = new DateTime(2020, 8, 3);
        var actual = date.GetDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Sunday);
        Assert.AreEqual(new DateTime(2020, 8, 2), actual.Date);
    }


    [TestMethod]
    public void GetDayOfWeekk_WeekStartsMonday_ReturnsSaturdayAfterDate()
    {
        var date = new DateTime(2020, 8, 3);
        var actual = date.GetDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Monday);
        Assert.AreEqual(new DateTime(2020, 8, 9), actual.Date);
    }


    [TestMethod]
    public void GetDayOfWeek_Today_ReturnsToday()
    {
        var date = DateTime.Now;
        var actual = date.GetDayOfWeek(date.DayOfWeek, DayOfWeek.Monday);
        Assert.AreEqual(date.Date, actual.Date);
    }

    #endregion
}