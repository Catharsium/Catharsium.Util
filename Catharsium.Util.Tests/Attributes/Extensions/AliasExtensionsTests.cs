using Catharsium.Util.Attributes.Extensions;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Attributes.Extensions
{
    [TestClass]
    public class AliasExtensionsTests
    {
        [TestMethod]
        public void GetAlias_ValidIndex_ReturnsAliasAtIndex()
        {
            var actual = MockEnum.First.GetAlias(0);
            Assert.AreEqual("1", actual);
        }


        [TestMethod]
        public void GetAlias_InvalidIndex_ReturnsFallback()
        {
            var fallback = "My fallback";
            var actual = MockEnum.First.GetAlias(1, fallback);
            Assert.AreEqual(fallback, actual);
        }
    }
}