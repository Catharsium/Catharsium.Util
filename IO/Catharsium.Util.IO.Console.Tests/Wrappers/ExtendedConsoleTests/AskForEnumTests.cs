using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Tests._Fixture;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForEnumTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForEnum_WritesListOfItems() {
        this.Target.AskForEnum<MockEnum>();
        this.GetDependency<IConsoleWrapper>().Received().WriteLine($"[1] First");
        this.GetDependency<IConsoleWrapper>().Received().WriteLine($"[2] Second");
        this.GetDependency<IConsoleWrapper>().Received().WriteLine($"[3] Third");
    }


    [TestMethod]
    public void AskForEnum_WithMessage_WritesMessage() {
        var message = "My message";
        this.Target.AskForEnum<MockEnum>(message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForEnum_ValidInt_ReturnsValue() {
        var selectedIndex = 2;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForEnum<MockEnum>();
        Assert.AreEqual(MockEnum.Second, actual);
    }


    [TestMethod]
    public void AskForEnum_NotAnInt_ReturnsNull() {
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not an int");
        var actual = this.Target.AskForEnum<MockEnum>();
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void AskForEnum_InvalidInt_ReturnsNull() {
        var items = new List<int> { 987, 654, 321 };
        var selectedIndex = items.Count + 1;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForEnum<MockEnum>();
        Assert.IsNull(actual);
    }
}