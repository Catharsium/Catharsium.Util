using Catharsium.Util.Privacy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.Util.Tests.Privacy;

[TestClass]
public class MaskingToolTests
{
    #region Fixture

    private MaskingTool Target { get; set; }


    [TestInitialize]
    public void Setup()
    {
        this.Target = new MaskingTool();
    }

    #endregion

    #region MaskEmail

    [TestMethod]
    public void MaskEmail_ValidShortEmail_ReturnsMaskedResult()
    {
        var actual = this.Target.MaskEmail("email@domain.net");
        Assert.AreEqual("e***l@domain.net", actual);
    }


    [TestMethod]
    public void MaskEmail_ValidLongEmail_ReturnsMaskedResult()
    {
        var actual = this.Target.MaskEmail("my.email@domain.net");
        Assert.AreEqual("m******l@domain.net", actual);
    }

    #endregion

    #region MaskPhoneNumber

    [TestMethod]
    public void MaskPhoneNumber_ValidDutchMobilePhoneNumber_ReturnsMaskedResult()
    {
        var actual = this.Target.MaskPhoneNumber("0612345678");
        Assert.AreEqual("0612****78", actual);
    }


    [TestMethod]
    public void MaskPhoneNumber_ValidForeignMobilePhoneNumber_ReturnsMaskedResult()
    {
        var actual = this.Target.MaskPhoneNumber("+49612345678");
        Assert.AreEqual("+49612****78", actual);
    }


    [TestMethod]
    public void MaskPhoneNumber_ValidForeignMobilePhoneNumberWithLeadingZeros_ReturnsMaskedResult()
    {
        var actual = this.Target.MaskPhoneNumber("0049612345678");
        Assert.AreEqual("0049612****78", actual);
    }


    [TestMethod]
    public void MaskPhoneNumber_EmptyString_ReturnsEmptyString()
    {
        var actual = this.Target.MaskPhoneNumber("");
        Assert.AreEqual("", actual);
    }


    [TestMethod]
    public void MaskPhoneNumber_null_ReturnsNull()
    {
        var actual = this.Target.MaskPhoneNumber(null);
        Assert.AreEqual(null, actual);
    }

    #endregion
}