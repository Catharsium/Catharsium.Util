using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class GetDependencySubstitutesTests
    {
        #region Fixture
        
        private TargetFactory<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new TargetFactory<MockObject>();
        }

        #endregion

        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithInterfaceDependencies_ReturnsSubstitutes()
        {
            var constructor = typeof(MockObject).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList()[1];
            var actual = this.Target.GetDependencySubstitutes(constructor);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencySubstitutes_NullConstructor_ReturnsEmptySubstitutes()
        {
            var actual = this.Target.GetDependencySubstitutes(null);
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }
    }
}