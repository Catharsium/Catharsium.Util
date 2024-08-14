using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForDecimalTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForDecimal_WithText_WritesText() {
        var message = "My message";
        this.Target.AskForDecimal(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForDecimal_NoText_DoesNotWriteText() {
        this.Target.AskForDecimal();
        this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
    }


    [TestMethod]
    public void AskForDecimal_ValidDecimal_ReturnsReadLineAsDecimal() {
        var message = "My message";
        var expected = 123.456M;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

        var actual = this.Target.AskForDecimal(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void AskForDecimal_NotADecimal_ReturnsNull() {
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");

        var actual = this.Target.AskForDecimal(message);
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void AskForDecimal_DefaultValue_ValidNumber_ReturnsDefaultValue() {
        var expected = 123;
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

        var actual = this.Target.AskForDecimal(expected + 1, message);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void AskForDecimal_DefaultValue_InvalidNumber_ReturnsDefaultValue() {
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");
        var expected = 123;

        var actual = this.Target.AskForDecimal(expected, message);
        Assert.AreEqual(expected, actual);
    }
}