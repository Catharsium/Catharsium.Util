using Catharsium.Util.IO.Console;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Console.ConsoleReaderTests
{
    [TestClass]
    public class ReadIntTests : TestFixture<ExtendedConsole>
    {
        [TestMethod]
        public void ReadInt_WithText_WritesText()
        {
            var message = "My message";
            this.Target.ReadInt(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        }
        

        [TestMethod]
        public void ReadInt_NoText_DoesNotWriteText()
        {
            this.Target.ReadInt(null);
            this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
        }


        [TestMethod]
        public void ReadInt_ValidInt_ReturnsReadLineAsInt()
        {
            var message = "My message";
            var expected = 123;
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

            var actual = this.Target.ReadInt(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ReadInt_NotAnInt_ReturnsNull()
        {
            var message = "My message";
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");

            var actual = this.Target.ReadInt(message);
            Assert.IsNull(actual);
        }
    }
}