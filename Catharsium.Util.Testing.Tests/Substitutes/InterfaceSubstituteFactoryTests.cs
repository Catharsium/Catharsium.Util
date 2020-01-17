using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class InterfaceSubstituteFactoryTests : TestFixture<InterfaceSubstituteFactory>
    {
        [TestMethod]
        public void CanCreateFor_Interface_ReturnsTrue()
        {
            var type = typeof(IMockInterface1);
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
            var type = typeof(IMockInterface1);
            var actual = this.Target.CreateSubstitute(type);
            Assert.IsNotNull(actual);
        }
    }
}