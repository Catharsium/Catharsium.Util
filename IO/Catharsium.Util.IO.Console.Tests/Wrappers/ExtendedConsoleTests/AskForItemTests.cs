using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForItemTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForItem_WritesListOfItems() {
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        this.Target.AskForItem(items);
        for(var i = 1; i <= items.Count; i++) {
            this.GetDependency<IConsoleWrapper>().Received().WriteLine($"[{i}] {items[i - 1]}");
        }
    }


    [TestMethod]
    public void AskForItem_WithMessage_WritesMessage() {
        var message = "My message";
        this.Target.AskForItem(Array.Empty<string>(), message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForItem_ValidInt_ReturnsItem() {
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        var selectedIndex = 1;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForItem(items);
        Assert.AreEqual(items[selectedIndex - 1], actual);
    }


    [TestMethod]
    public void AskForItem_NotAnInt_ReturnsNull() {
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not an int");

        var actual = this.Target.AskForItem(items);
        Assert.IsNull(actual);
    }


    [TestMethod]
    public void AskForItem_InvalidInt_ReturnsNull() {
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        var selectedIndex = items.Count + 1;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForItem(items);
        Assert.IsNull(actual);
    }
}