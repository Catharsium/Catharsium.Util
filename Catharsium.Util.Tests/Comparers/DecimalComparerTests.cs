using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Comparers
{
    [TestClass]
    public class DecimalComparerTests : TestFixture<DecimalComparer>
    {
        #region Fixture

        private static decimal X => 10;

        #endregion

        [TestMethod]
        public void Compare_Decimal_XGreaterThanY_ReturnsPositive()
        {
            var y = X - 1;
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual > 0);
        }


        [TestMethod]
        public void Compare_Decimal_XEqualToY_ReturnsZero()
        {
            var y = X;
            var actual = this.Target.Compare(X, y);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void Compare_Decimal_XLessThanY_ReturnsNegative()
        {
            var y = X + 1;
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual < 0);
        }
    }
}