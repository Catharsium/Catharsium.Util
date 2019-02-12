using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class GetDependenciesTests
    {
        #region Fixture

        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new DependencyRetriever();
        }

        #endregion

        #region GetDependencies

        [TestMethod]
        public void GetDependencies_NoDependencies_ReturnsEmptyList()
        {
            var actual = this.Target.GetDependencies<object>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }


        [TestMethod]
        public void GetDependencies_ConstructorWithAllDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObject>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Contains(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencies_SingleConstructors_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObjectWithSingleConstructor>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Contains(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencies_ConstructorWithoutInterfaceDependencies_ReturnsEmptyList()
        {
            var actual = this.Target.GetDependencies<MockObjectWithoutInterfaces>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }


        [TestMethod]
        public void GetDependencies_MultipleConstructorsWithDifferentDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObjectWithDifferentDependencies>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Contains(typeof(IMockInterface2)));
        }

        #endregion
    }
}