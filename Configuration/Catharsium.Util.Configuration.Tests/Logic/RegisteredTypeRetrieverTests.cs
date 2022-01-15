using Catharsium.Util.Configuration.Logic;
using Catharsium.Util.Configuration.Tests._Mocks;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Catharsium.Util.Configuration.Tests.Logic;

[TestClass]
public class RegisteredTypeRetrieverTests : TestFixture<RegisteredTypeRetriever<IType>>
{
    [TestMethod]
    public void Get_RegisteredType_ReturnsInstance()
    {
        var actionHandlers = new List<IType> { new ImplementationType() };
        this.SetDependency<IEnumerable<IType>>(actionHandlers);

        var actual = this.Target.Get<ImplementationType>();
        Assert.IsNotNull(actual);
        var actualType = actual.GetType();
        Assert.AreEqual(typeof(ImplementationType), actualType);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Get_OtherType_ThrowsException()
    {
        this.Target.Get<ImplementationType>();
    }
}