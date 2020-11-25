using Catharsium.Util.Interfaces;
using Catharsium.Util.Reflection.Types;
using Catharsium.Util.Testing;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Catharsium.Util.Tests.Reflection.Types
{
    [TestClass]
    public class TypesRetrieverTests : TestFixture<TypesRetriever>
    {
        #region GetImplementationsFor (Current)

        [TestMethod]
        public void GetImplementations_Current_TypesThatImplementTheInterface_AreReturned()
        {
            var actual = this.Target.GetImplementationsFor<ITypesRetriever>();
            Assert.IsTrue(actual.Contains(typeof(TypesRetriever)));
        }


        [TestMethod]
        public void GetImplementations_Current_InterfaceWithoutImplementations_ReturnsEmpty()
        {
            var actual = this.Target.GetImplementationsFor<IMockInterfaceWithoutImplementations>();
            Assert.AreEqual(0, actual.Count());
        }

        #endregion
    }
}