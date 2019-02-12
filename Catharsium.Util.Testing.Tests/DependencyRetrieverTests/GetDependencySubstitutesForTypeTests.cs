using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.DependencyRetrieverTests
{
    [TestClass]
    public class GetDependencySubstitutesForTypeTests
    {
        #region Fixture

        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new DependencyRetriever();
        }

        #endregion

        #region GetDependencySubstitutes

        [TestMethod]
        public void GetDependencySubstitutes_NoDependencies_ReturnsEmptyList()
        {
            var actual = this.Target.GetDependencySubstitutes<object>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }


        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithAllDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencySubstitutes<MockObject>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencySubstitutes_SingleConstructors_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencySubstitutes<MockObjectWithSingleConstructor>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithoutInterfaceDependencies_ReturnsEmptyList()
        {
            var actual = this.Target.GetDependencySubstitutes<MockObjectWithoutInterfaces>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }


        [TestMethod]
        public void GetDependencySubstitutes_MultipleConstructorsWithDifferentDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencySubstitutes<MockObjectWithDifferentDependencies>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }

        #endregion
    }
}