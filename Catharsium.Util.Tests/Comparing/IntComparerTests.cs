using System.Collections.Generic;
using Catharsium.Util.Comparing;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Comparing
{
    [TestClass]
    public class IntComparerTests : TestFixture<IntComparer>
    {
        #region Fixture

        private static int X => 10;

        #endregion

        [TestMethod]
        public void Compare_Int_XGreaterThanY_ReturnsDecimalComparisonResult()
        {
            var y = X - 1;
            this.GetDependency<IComparer<decimal>>().Compare(X, y).Returns(1);
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual > 0);
        }


        [TestMethod]
        public void Compare_Int_XEqualToY_ReturnsDecimalComparisonResult()
        {
            var y = X + 1;
            this.GetDependency<IComparer<decimal>>().Compare(X, y).Returns(0);
            var actual = this.Target.Compare(X, y);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void Compare_Int_XLessThanY_ReturnsDecimalComparisonResult()
        {
            var y = X + 1;
            this.GetDependency<IComparer<decimal>>().Compare(X, y).Returns(-1);
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual < 0);
        }
    }
}