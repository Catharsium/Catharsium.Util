using Catharsium.Util.Reflection.Attributes.Extensions;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Reflection.Attributes.Extensions;

[TestClass]
public class AliasExtensionsTests
{
    [TestMethod]
    public void GetAlias_ValidIndex_ReturnsAliasAtIndex() {
        var actual = MockEnumeration.First.GetAlias(0);
        Assert.AreEqual("1", actual);
    }


    [TestMethod]
    public void GetAlias_InvalidIndex_ReturnsFallback() {
        var fallback = "My fallback";
        var actual = MockEnumeration.First.GetAlias(1, fallback);
        Assert.AreEqual(fallback, actual);
    }
}