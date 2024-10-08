﻿using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForIntTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForInt_WithText_WritesText() {
        var message = "My message";
        this.Target.AskForInt(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForInt_NoText_DoesNotWriteText() {
        this.Target.AskForInt();
        this.GetDependency<IConsoleWrapper>().DidNotReceive().WriteLine(Arg.Any<string>());
    }


    [TestMethod]
    public void AskForInt_ValidInt_ReturnsReadLineAsInt() {
        var message = "My message";
        var expected = 123;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

        var actual = this.Target.AskForInt(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void AskForInt_NotAnInt_ReturnsNull() {
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");

        var actual = this.Target.AskForInt(message);
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void AskForInt_DefaultValue_ValidNumber_ReturnsDefaultValue() {
        var expected = 123;
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(expected.ToString());

        var actual = this.Target.AskForInt(expected + 1, message);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void AskForInt_DefaultValue_InvalidNumber_ReturnsDefaultValue() {
        var message = "My message";
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not a number");
        var expected = 123;

        var actual = this.Target.AskForInt(expected, message);
        Assert.AreEqual(expected, actual);
    }
}