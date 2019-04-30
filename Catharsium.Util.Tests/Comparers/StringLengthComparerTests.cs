using System.Collections.Generic;
using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Comparers
{
    [TestClass]
    public class StringLengthComparerTests : TestFixture<StringLengthComparer>
    {
        #region Fixture

        private static string X => "My string";

        #endregion

        [TestMethod]
        public void Compare_String_XLongerThanY_ReturnsPositive()
        {
            var y = X + "y";
            this.GetDependency<IComparer<int>>().Compare(X.Length, y.Length).Returns(1);
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual > 0);
        }


        [TestMethod]
        public void Compare_String_XEqualToY_ReturnsZero()
        {
            var y = X + 1;
            this.GetDependency<IComparer<int>>().Compare(X.Length, y.Length).Returns(0);
            var actual = this.Target.Compare(X, y);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void Compare_String_XShorterThanY_ReturnsNegative()
        {
            var y = X.Substring(0, X.Length - 2);
            this.GetDependency<IComparer<int>>().Compare(X.Length, y.Length).Returns(-1);
            var actual = this.Target.Compare(X, y);
            Assert.IsTrue(actual < 0);
        }


        [TestMethod]
        public void Compare_String_XIsNull_ReturnsZero()
        {
            var y = "My y";
            var actual = this.Target.Compare(null, y);
            Assert.AreEqual(0, actual);
        }

        
        [TestMethod]
        public void Compare_String_YIsNull_ReturnsZero()
        {
            var actual = this.Target.Compare(X, null);
            Assert.AreEqual(0, actual);
        }
    }
}