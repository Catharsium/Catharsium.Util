using Catharsium.Util.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Catharsium.Util.Web.Tests.Extensions;

[TestClass]
public class UrlExtensionsTests
{
    [TestMethod]
    public void AddQuery_NewVariables_AreAppended()
    {
        var url = "My url";
        var variables = new Dictionary<string, string> {
                {"Key1", "Value1"},
                {"Key2", "Value2"}
            };

        var actual = url.AddQuery(variables);
        Assert.AreEqual($"{url}?Key1=Value1&Key2=Value2", actual);
    }


    [TestMethod]
    public void AddQuery_ExistingVariables_AreNotAdded()
    {
        var url = "My url?Key1=Value1";
        var variables = new Dictionary<string, string> { { "Key1", "Value1" } };

        var actual = url.AddQuery(variables);
        Assert.AreEqual($"{url}?Key1=Value1", actual);
    }
}