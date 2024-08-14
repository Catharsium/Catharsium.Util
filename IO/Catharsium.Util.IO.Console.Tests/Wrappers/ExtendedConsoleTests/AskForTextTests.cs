using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForTextTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForText_WithText_WritesText() {
        var message = "My message";
        this.Target.AskForText(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForText_NoText_DoesNotWriteText() {
        this.Target.AskForText();
        this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
    }


    [TestMethod]
    public void AskForText_ValidInt_ReturnsReadLineAsInt() {
        var message = "My message";
        var expected = "My text";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected);

        var actual = this.Target.AskForText(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        Assert.AreEqual(expected, actual);
    }
}