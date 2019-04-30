using System;
using Catharsium.Util.Comparing;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Comparing.EnumerableEqualityComparerTests
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