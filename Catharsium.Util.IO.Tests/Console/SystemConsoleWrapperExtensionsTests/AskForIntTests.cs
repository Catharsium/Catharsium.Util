using Catharsium.Util.IO.Console;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Console.ConsoleReaderTests
{
    [TestClass]
    public class AskForIntTests : TestFixture<ExtendedConsole>
    {
        [TestMethod]
        public void AskForInt_WithText_WritesText()
        {
            var message = "My message";
            this.Target.AskForInt(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        }


        [TestMethod]
        public void AskForInt_NoText_DoesNotWriteText()
        {
            this.Target.AskForInt(null);
            this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
        }


        [TestMethod]
        public void AskForInt_ValidInt_ReturnsReadLineAsInt()
        {
            var message = "My message";
            var expected = 123;
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

            var actual = this.Target.AskForInt(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AskForInt_NotAnInt_ReturnsNull()
        {
            var message = "My message";
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");

            var actual = this.Target.AskForInt(message);
            Assert.IsNull(actual);
        }
    }
}