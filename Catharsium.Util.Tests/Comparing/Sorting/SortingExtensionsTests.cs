using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Comparing.Sorting
{
    [TestClass]
    public class SortingExtensionsTests
    {
        #region Fixture

        private IComparer<decimal> Comparer { get; set; }


        [TestInitialize]
        public void SetupDependencies()
        {
            this.Comparer = new DecimalComparer();
        }

        #endregion

        [TestMethod]
        public void QuickSort_ReturnsQuickSorterSortResult()
        {
            var input = new[] {1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m};
            var expected = new QuickSorter<decimal>(this.Comparer).Sort(input).ToList();

            var actual = input.QuickSort(this.Comparer).ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}