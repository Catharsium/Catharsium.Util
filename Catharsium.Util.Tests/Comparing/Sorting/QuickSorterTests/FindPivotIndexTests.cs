using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Tests.Comparing.Sorting.QuickSorterTests;

[TestClass]
public class FindPivotTests : TestFixture<QuickSorter<decimal>>
{
    #region Fixture

    [TestInitialize]
    public void SetupDependencies() {
        this.SetDependency<IComparer<decimal>>(new DecimalComparer());
    }

    #endregion

    #region FindPivot

    [TestMethod]
    public void FindPivotIndex_MultipleOddItems_ReturnsMedianOfFirstMiddleAndLast() {
        var input = new[] { 3m, 1m, 2m, 7m, 5m, 9m, 8m, 4m, 6m };
        var actual = this.Target.FindPivotIndex(input);
        Assert.AreEqual(input.Length / 2, actual);
    }


    [TestMethod]
    public void FindPivotIndex_MultipleEvenItems_ReturnsUsesIndexAfterMiddleAsMiddle() {
        var input = new[] { 4m, 3m, 2m, 1m };
        var actual = this.Target.FindPivotIndex(input);
        Assert.AreEqual(input.Length / 2, actual);
    }


    [TestMethod]
    public void FindPivotIndex_TwoItems_ReturnsFirst() {
        var input = new[] { 1m, 2m };
        var actual = this.Target.FindPivotIndex(input);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void FindPivotIndex_SingleItem_ReturnsZero() {
        var input = new[] { 1m };
        var actual = this.Target.FindPivotIndex(input);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void FindPivotIndex_EmptyList_ReturnsNegativeOne() {
        var input = Array.Empty<decimal>();
        var actual = this.Target.FindPivotIndex(input);
        Assert.AreEqual(-1, actual);
    }

    #endregion
}