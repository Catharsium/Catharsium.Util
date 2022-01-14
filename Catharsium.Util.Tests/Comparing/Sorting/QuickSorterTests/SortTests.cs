using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Catharsium.Util.Tests.Comparing.Sorting.QuickSorterTests;

[TestClass]
public class SortTests : TestFixture<QuickSorter<decimal>>
{
    #region Fixture

    [TestInitialize]
    public void SetupDependencies()
    {
        this.SetDependency<IComparer<decimal>>(new DecimalComparer());
    }

    #endregion

    #region Sort

    [TestMethod]
    public void Sort_EmptyList_ReturnsEmptyList()
    {
        var input = Array.Empty<decimal>();
        var actual = this.Target.Sort(input);
        Assert.AreEqual(0, actual.Count());
    }


    [TestMethod]
    public void Sort_SingleItem_ReturnsItem()
    {
        var input = new[] { 0m };
        var actual = this.Target.Sort(input);
        Assert.AreEqual(input.Length, actual.Count());
    }


    [TestMethod]
    public void Sort_SortedList_ReturnsUnchanged()
    {
        var input = new[] { 1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m };
        var actual = this.Target.Sort(input).ToList();
        Assert.AreEqual(input.Length, actual.Count);
        for (var i = 0; i < input.Length - 1; i++) {
            Assert.IsTrue(input[i] == actual[i]);
        }
    }


    [TestMethod]
    public void Sort_MultipleItems_ReturnsSortedItems()
    {
        var input = new[] { 5m, 1m, 2m, 7m, 3m, 9m, 8m, 4m, 6m };
        var actual = this.Target.Sort(input).ToList();
        Assert.AreEqual(input.Length, actual.Count);
        for (var i = 1; i < input.Length - 1; i++) {
            Assert.IsTrue(actual[i - 1] < actual[i]);
            Assert.IsTrue(actual[i] < actual[i + 1]);
        }
    }

    #endregion
}