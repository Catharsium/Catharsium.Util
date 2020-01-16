using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;

namespace Catharsium.Util.Testing.Tests.DependencyRetrieverTests
{
    [TestClass]
    public class GetDependenciesTests
    {
        #region Fixture

        private ISubstituteService SubstituteFactory { get; set; }

        private DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.SubstituteFactory = Substitute.For<ISubstituteService>();
            this.Target = new DependencyRetriever(this.SubstituteFactory);
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
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1)));
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencies_SingleConstructors_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObjectWithSingleConstructor>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1)));
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2)));
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
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface1)));
            Assert.IsTrue(actual.Any(d => d.Type == typeof(IMockInterface2)));
        }

        #endregion
    }
}