using Catharsium.Util.Filters;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
namespace Catharsium.Util.Tests.Filters;

[TestClass]
public class OrFilterTests : TestFixture<OrFilter<string>>
{
    #region Fixture

    private IFilter<string> FirstFilter { get; set; }
    private IFilter<string> SecondFilter { get; set; }


    [TestInitialize]
    public void SetupDependencies()
    {
        this.FirstFilter = Substitute.For<IFilter<string>>();
        this.SecondFilter = Substitute.For<IFilter<string>>();
    }

    #endregion

    #region Includes

    [TestMethod]
    public void Includes_AllFiltersSucceed_ReturnsTrue()
    {
        this.FirstFilter.Includes(Arg.Any<string>()).Returns(true);
        this.SecondFilter.Includes(Arg.Any<string>()).Returns(true);
        this.Target.Filters = new List<IFilter<string>> { this.FirstFilter, this.SecondFilter };

        var actual = this.Target.Includes("");
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_SingleFiltersSucceeds_ReturnsTrue()
    {
        this.FirstFilter.Includes(Arg.Any<string>()).Returns(true);
        this.SecondFilter.Includes(Arg.Any<string>()).Returns(false);
        this.Target.Filters = new List<IFilter<string>> { this.FirstFilter, this.SecondFilter };

        var actual = this.Target.Includes("");
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_AllFiltersFail_ReturnsFalse()
    {
        this.FirstFilter.Includes(Arg.Any<string>()).Returns(false);
        this.SecondFilter.Includes(Arg.Any<string>()).Returns(false);
        this.Target.Filters = new List<IFilter<string>> { this.FirstFilter, this.SecondFilter };

        var actual = this.Target.Includes("");
        Assert.IsFalse(actual);
    }

    #endregion
}