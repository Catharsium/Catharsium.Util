using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests;

[TestClass]
public class AskForItem_WithObjectsTests : TestFixture<ExtendedConsole>
{
    [TestMethod]
    public void AskForItem_WithObjects_WritesListOfItems()
    {
        var items = new List<int> { 987, 654, 321 };
        this.Target.AskForItem(items);
        for (var i = 1; i <= items.Count; i++) {
            this.GetDependency<IConsoleWrapper>().Received().WriteLine($"[{i}] {items[i - 1]}");
        }
    }


    [TestMethod]
    public void AskForItem_WithObjects_WithMessage_WritesMessage()
    {
        var message = "My message";
        this.Target.AskForItem(new int[0], message);
        this.GetDependency<IConsoleWrapper>().Received().WriteLine(message);
    }


    [TestMethod]
    public void AskForItem_WithObjects_ValidInt_ReturnsItem()
    {
        var items = new List<int> { 987, 654, 321 };
        var selectedIndex = 1;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForItem(items);
        Assert.AreEqual(items[selectedIndex - 1], actual);
    }


    [TestMethod]
    public void AskForItem_WithObjects_NotAnInt_ReturnsNull()
    {
        var items = new List<int> { 987, 654, 321 };
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns("Not an int");

        var actual = this.Target.AskForItem(items);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void AskForItem_WithObjects_InvalidInt_ReturnsNull()
    {
        var items = new List<int> { 987, 654, 321 };
        var selectedIndex = items.Count + 1;
        this.GetDependency<IConsoleWrapper>().ReadLine().Returns(selectedIndex.ToString());

        var actual = this.Target.AskForItem(items);
        Assert.AreEqual(0, actual);
    }
}