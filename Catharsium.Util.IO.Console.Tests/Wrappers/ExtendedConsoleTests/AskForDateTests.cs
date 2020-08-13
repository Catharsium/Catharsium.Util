using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests
{
    [TestClass]
    public class AskForDateTests : TestFixture<ExtendedConsole>
    {
        [TestMethod]
        public void AskForDate_WithText_WritesText()
        {
            var message = "My message";
            this.Target.AskForDate(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        }


        [TestMethod]
        public void AskForDate_NoText_DoesNotWriteText()
        {
            this.Target.AskForDate();
            this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
        }


        [TestMethod]
        public void AskForDate_ValidDate_WithTime_ReturnsReadLineAsDateWithTime()
        {
            var message = "My message";
            var expected = new DateTime(2019, 12, 31, 13, 30, 50);
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString("yyyy MM dd HH mm ss"));

            var actual = this.Target.AskForDate(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AskForDate_ValidDate_WithoutSeconds_ReturnsReadLineAsDateWithTime()
        {
            var message = "My message";
            var expected = new DateTime(2019, 12, 31, 13, 30, 0);
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString("yyyy MM dd HH mm"));

            var actual = this.Target.AskForDate(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AskForDate_ValidDate_WithoutTime_ReturnsReadLineAsDate()
        {
            var message = "My message";
            var expected = new DateTime(2019, 12, 31);
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString("yyyy MM dd"));

            var actual = this.Target.AskForDate(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AskForDate_ValidDate_WithSymbols_ReturnsReadLineAsDate()
        {
            var message = "My message";
            var expected = new DateTime(2019, 12, 31, 13, 30, 0);
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString("yyyy-MM-dd HH:mm"));

            var actual = this.Target.AskForDate(message);
            this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AskForDate_NotADate_ReturnsNull()
        {
            var message = "My message";
            this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a date");

            var actual = this.Target.AskForDate(message);
            Assert.IsNull(actual);
        }
    }
}