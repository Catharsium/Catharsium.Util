using Catharsium.Util.IO.Console.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Tests._Mocks;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Tests.ActionHandlers
{
    [TestClass]
    public class ActionHandlerRetrieverTests : TestFixture<ActionHandlerRetriever>
    {
        [TestMethod]
        public void Get_RegisteredActionHandler_ReturnsInstance()
        {
            var actionHandlers = new List<IActionHandler> { new MyActionHandler() };
            this.SetDependency<IEnumerable<IActionHandler>>(actionHandlers);

            var actual = this.Target.Get<MyActionHandler>();
            Assert.IsNotNull(actual);
            var actualType = actual.GetType();
            Assert.AreEqual(typeof(MyActionHandler), actualType);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_OtherActionHandler_ThrowsException()
        {
            this.Target.Get<MyActionHandler>();
        }
    }
}