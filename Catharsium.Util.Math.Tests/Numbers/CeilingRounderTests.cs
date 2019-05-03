using Catharsium.Util.Math.Numbers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Math.Tests.Numbers
{
    [TestClass]
    public class CeilingRounderTests : TestFixture<CeilingRounder>
    {
        [TestMethod]
        public void Round_WholeNumber_NoDecimals_ReturnsUnchangedNumber()
        {
            var input = 1m;
            var actual = this.Target.Round(input);
            Assert.AreEqual(input, actual);
        }


        [TestMethod]
        public void Round_TrailingZeros_NoDecimals_ReturnsRoundedNumber()
        {
            var input = 1.00m;
            var actual = this.Target.Round(input);
            Assert.AreEqual(1m, actual);
        }


        [TestMethod]
        public void Round_WholeNumber_OneDecimal_ReturnsNumberWithOne0Decimal()
        {
            var input = 1m;
            var actual = this.Target.Round(input, 1);
            Assert.AreEqual(1.0m, actual);
        }


        [TestMethod]
        public void Round_Decimal4_NoDecimals_IsRoundedUp()
        {
            var input = 1.4m;
            var actual = this.Target.Round(input);
            Assert.AreEqual(2m, actual);
        }


        [TestMethod]
        public void Round_Decimal5_NoDecimals_IsRoundedUp()
        {
            var input = 1.5m;
            var actual = this.Target.Round(input);
            Assert.AreEqual(2m, actual);
        }


        [TestMethod]
        public void Round_Decimal999_TwoDecimals_IsRoundedDown()
        {
            var input = 1.999m;
            var actual = this.Target.Round(input, 2);
            Assert.AreEqual(2.00m, actual);
        }
    }
}