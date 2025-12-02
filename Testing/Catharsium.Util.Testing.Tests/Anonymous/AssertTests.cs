using Catharsium.Util.Testing.Anonymous;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Anonymous;

[TestClass]
public class AssertAnonymousTests
{
    [TestMethod]
    public void AreEqual_EqualValues_AreEqual() {
        var x = new { Id = 123, Value = "My value" };
        var y = new { Id = 123, Value = "My value" };
        AssertAnonymous.AreEqual(x, y);
    }


    [TestMethod]
    public void AreEqual_AnonymousAndConcreteType_AreEqual() {
        var x = new { Id = 123, Value = "My value" };
        var y = new MyType { Id = 123, Value = "My value" };
        AssertAnonymous.AreEqual(x, y);
    }


    [TestMethod]
    public void AreEqual_EqualComplexValues_AreEqual() {
        var x = new { Id = 123, Value = "My value", Child = new { Name = "My child name" } };
        var y = new { Id = 123, Value = "My value", Child = new { Name = "My child name" } };
        AssertAnonymous.AreEqual(x, y);
    }


    [TestMethod]
    public void AreEqual_DifferentValue_AreNotEqual() {
        var x = new { Id = 123, Value = "My value" };
        var y = new { Id = 123, Value = "My other value" };
        Assert.Throws<AssertFailedException>(() => AssertAnonymous.AreEqual(x, y));
    }


    [TestMethod]
    public void AreEqual_DifferentNestedValue_AreNotEqual() {
        var x = new { Id = 123, Value = "My value", Child = new { Name = "My child name" } };
        var y = new { Id = 123, Value = "My value", Child = new { Name = "My other child name" } };
        Assert.Throws<AssertFailedException>(() => AssertAnonymous.AreEqual(x, y));
    }
}



public class MyType
{
    public int Id { get; set; }
    public string Value { get; set; }
}