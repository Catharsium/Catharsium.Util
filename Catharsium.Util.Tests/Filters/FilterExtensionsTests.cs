using Catharsium.Util.Filters;
using Catharsium.Util.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;

namespace Catharsium.Util.Tests.Filters;

[TestClass]
public class FilterExtensionsTests
{
    #region Include

    [TestMethod]
    public void Include_FilterIncludingEverything_ReturnsAll() {
        var items = new[] { new object() };
        var filter = Substitute.For<IFilter<object>>();
        filter.Includes(Arg.Any<object>()).Returns(true);

        var actual = items.Include(filter);
        Assert.AreEqual(items.Length, actual.Count());
    }


    [TestMethod]
    public void Include_FilterIncludingNothing_ReturnsNothing() {
        var transactions = new[] { new object() };
        var filter = Substitute.For<IFilter<object>>();
        filter.Includes(Arg.Any<object>()).Returns(false);

        var actual = transactions.Include(filter);
        Assert.AreEqual(0, actual.Count());
    }

    #endregion

    #region Exclude

    [TestMethod]
    public void Exclude_FilterIncludingEverything_ReturnsNothing() {
        var transactions = new[] { new object() };
        var filter = Substitute.For<IFilter<object>>();
        filter.Includes(Arg.Any<object>()).Returns(true);

        var actual = transactions.Exclude(filter);
        Assert.AreEqual(0, actual.Count());
    }


    [TestMethod]
    public void Exclude_FilterIncludingNothing_ReturnsAll() {
        var transactions = new[] { new object() };
        var filter = Substitute.For<IFilter<object>>();
        filter.Includes(Arg.Any<object>()).Returns(false);

        var actual = transactions.Exclude(filter);
        Assert.AreEqual(transactions.Length, actual.Count());
    }

    #endregion
}