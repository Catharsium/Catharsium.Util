using Catharsium.Util.Comparing.Equality;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Comparing.Equality.EnumerableEqualityComparerTests
{
    [TestClass]
    public class GetHashCodeTests : TestFixture<EnumerableEqualityComparer<int>>
    {
        #region GetHashCode

        [TestMethod]
        public void GetHashCode_ReturnsObjectHashcode()
        {
            var input = Array.Empty<int>();
            var actual = this.Target.GetHashCode(input);
            Assert.AreEqual(input.GetHashCode(), actual);
        }

        #endregion
    }
}