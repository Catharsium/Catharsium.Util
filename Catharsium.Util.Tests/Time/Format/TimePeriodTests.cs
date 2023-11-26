using Catharsium.Util.Testing;
using Catharsium.Util.Time.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Time.Format;

[TestClass]
public class TimePeriodTests : TestFixture<TimePeriod>
{
    #region Properties

    [TestMethod]
    public void Weeks_ValueGreaterThan52_OverflowsToYears() {
        this.Target.Years = 1;
        this.Target.Weeks += 52 * 2 + 4;
        Assert.AreEqual(3, this.Target.Years);
        Assert.AreEqual(4, this.Target.Weeks);
    }


    [TestMethod]
    public void Days_ValueGreaterThan7_OverflowsToWeeks() {
        this.Target.Weeks = 1;
        this.Target.Days += 7 * 2 + 4;
        Assert.AreEqual(3, this.Target.Weeks);
        Assert.AreEqual(4, this.Target.Days);
    }


    [TestMethod]
    public void Hours_ValueGreaterThan24_OverflowsToDays() {
        this.Target.Days = 1;
        this.Target.Hours += 24 * 2 + 4;
        Assert.AreEqual(3, this.Target.Days);
        Assert.AreEqual(4, this.Target.Hours);
    }


    [TestMethod]
    public void Minutes_ValueGreaterThan60_OverflowsToHours() {
        this.Target.Hours = 1;
        this.Target.Minutes += 60 * 2 + 4;
        Assert.AreEqual(3, this.Target.Hours);
        Assert.AreEqual(4, this.Target.Minutes);
    }


    [TestMethod]
    public void Seconds_ValueGreaterThan60_OverflowsToMinutes() {
        this.Target.Minutes = 1;
        this.Target.Seconds += 60 * 2 + 4;
        Assert.AreEqual(3, this.Target.Minutes);
        Assert.AreEqual(4, this.Target.Seconds);
    }

    #endregion

    #region Operator +

    [TestMethod]
    public void OperatorPlus_TwoPeriods_ReturnsSum() {
        var p1 = new TimePeriod(1, 2, 3, 4, 5, 6);
        var p2 = new TimePeriod(8, 7, 3, 5, 4, 3);

        var actual = p1 + p2;
        Assert.AreEqual(p1.Years + p2.Years, actual.Years);
        Assert.AreEqual(p1.Weeks + p2.Weeks, actual.Weeks);
        Assert.AreEqual(p1.Days + p2.Days, actual.Days);
        Assert.AreEqual(p1.Hours + p2.Hours, actual.Hours);
        Assert.AreEqual(p1.Minutes + p2.Minutes, actual.Minutes);
        Assert.AreEqual(p1.Seconds + p2.Seconds, actual.Seconds);
    }

    #endregion

    #region ToTimeSpan

    [TestMethod]
    public void ToTimeSpan_IncludesYears() {
        var quantity = 3;
        this.Target.Years = quantity;
        var actual = this.Target.ToTimeSpan();
        Assert.AreEqual(new TimeSpan(365 * quantity, 0, 0, 0), actual);
    }


    [TestMethod]
    public void ToTimeSpan_IncludesWeeks() {
        var quantity = 3;
        this.Target.Weeks = quantity;
        var actual = this.Target.ToTimeSpan();
        Assert.AreEqual(new TimeSpan(7 * quantity, 0, 0, 0), actual);
    }


    [TestMethod]
    public void ToTimeSpan_IncludesHours() {
        var quantity = 3;
        this.Target.Hours = quantity;
        var actual = this.Target.ToTimeSpan();
        Assert.AreEqual(new TimeSpan(0, quantity, 0, 0), actual);
    }


    [TestMethod]
    public void ToTimeSpan_IncludesMinutes() {
        var quantity = 3;
        this.Target.Minutes = quantity;
        var actual = this.Target.ToTimeSpan();
        Assert.AreEqual(new TimeSpan(0, 0, quantity, 0), actual);
    }


    [TestMethod]
    public void ToTimeSpan_IncludesSeconds() {
        var quantity = 3;
        this.Target.Seconds = quantity;
        var actual = this.Target.ToTimeSpan();
        Assert.AreEqual(new TimeSpan(0, 0, 0, quantity), actual);
    }

    #endregion

    #region ToString

    public void ToString_ReturnsValuesInFormat() {
        this.Target.Years = 1;
        this.Target.Weeks = 2;
        this.Target.Days = 3;
        this.Target.Hours = 4;
        this.Target.Minutes = 5;
        this.Target.Seconds = 6;
        var expected = $"{this.Target.Years}y {this.Target.Weeks}w {this.Target.Days}d {this.Target.Hours}h {this.Target.Minutes}m {this.Target.Seconds}s";

        var actual = this.Target.ToString();
        Assert.AreEqual(expected, actual);
    }

    #endregion
}