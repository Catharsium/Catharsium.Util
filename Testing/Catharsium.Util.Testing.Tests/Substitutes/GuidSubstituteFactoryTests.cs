using Catharsium.Util.Testing.Substitutes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Catharsium.Util.Testing.Tests.Substitutes;

[TestClass]
public class GuidSubstituteFactoryTests : TestFixture<GuidSubstituteFactory>
{
    [TestMethod]
    public void CanCreateFor_Interface_ReturnsTrue()
    {
        var type = typeof(Guid);
        var actual = this.Target.CanCreateFor(type);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void CanCreateFor_NotAnInterface_ReturnsFalse()
    {
        var type = typeof(string);
        var actual = this.Target.CanCreateFor(type);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void CreateSubstitute_ReturnsSubstituteForType()
    {
        var type = typeof(Guid);
        var actual = this.Target.CreateSubstitute(type);
        Assert.IsNotNull(actual);
        Assert.AreEqual(type, actual.GetType());
    }
}