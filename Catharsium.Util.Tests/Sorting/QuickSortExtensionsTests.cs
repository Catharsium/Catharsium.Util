using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Comparers;
using Catharsium.Util.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Sorting
{
    [TestClass]
    public class QuickSortExtensionsTests
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
        public void QuickSort_EmptyList_ReturnsEmptyList()
        {
            var input = new decimal[0];
            var actual = input.QuickSort(this.Comparer);
            Assert.AreEqual(0, actual.Count());
        }


        [TestMethod]
        public void QuickSort_SingleItem_ReturnsItem()
        {
            var input = new[] {0m};
            var actual = input.QuickSort(this.Comparer);
            Assert.AreEqual(input.Length, actual.Count());
        }


        [TestMethod]
        public void QuickSort_SortedList_ReturnsUnchanged()
        {
            var input = new[] { 1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m };
            var actual = input.QuickSort(this.Comparer).ToList();
            Assert.AreEqual(input.Length, actual.Count);
            for (var i = 0; i < input.Length - 1; i++) {
                Assert.IsTrue(input[i] == actual[i]);
            }
        }


        [TestMethod]
        public void QuickSort_MultipleItems_ReturnsSortedItems()
        {
            var input = new[] {5m, 1m, 2m, 7m, 3m, 9m, 8m, 4m, 6m};
            var actual = input.QuickSort(this.Comparer).ToList();
            Assert.AreEqual(input.Length, actual.Count);
            for (var i = 1; i < input.Length - 1; i++) {
                Assert.IsTrue(actual[i - 1] < actual[i]);
                Assert.IsTrue(actual[i] < actual[i + 1]);
            }
        }
    }
}