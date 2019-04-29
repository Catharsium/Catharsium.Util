using System;
using Catharsium.Util.Testing.Tests._Mocks;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.TestFixtureTests
{
    [TestClass]
    public class TestFixtureIntegrationTests
    {
        #region Constructor

        [TestMethod]
        public void TestFixture_WorksWith_ALargestSatisfiableConstructor()
        {
            var actual = new TestFixture<MockObject>();
            Assert.IsNotNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(2, actual.Dependencies.Keys.Count);
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface2)));
            Assert.IsFalse(actual.Dependencies.ContainsKey(typeof(string)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_SingleConstructor()
        {
            var actual = new TestFixture<MockObjectWithSingleConstructor>();
            Assert.IsNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(2, actual.Dependencies.Keys.Count);
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_ConstructorWithoutInterfacesDependencies()
        {
            var actual = new TestFixture<MockObjectWithoutInterfaces>();
            Assert.IsNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(0, actual.Dependencies.Keys.Count);
        }


        [TestMethod]
        public void TestFixture_WorksWith_ConstructorsDifferentDependencies()
        {
            var actual = new TestFixture<MockObjectWithDifferentDependencies>();
            Assert.IsNotNull(actual.Target);
            Assert.IsNotNull(actual.Target.InterfaceDependency1);
            Assert.IsNull(actual.Target.InterfaceDependency2);
            Assert.IsNull(actual.Target.StringDependency);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(2, actual.Dependencies.Keys.Count);
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface2)));
            Assert.IsFalse(actual.Dependencies.ContainsKey(typeof(string)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_AllSupportedDependencies()
        {
            var actual = new TestFixture<MockObjectWithAllSupportedDependencies>();
            Assert.IsNotNull(actual.Target);
            Assert.IsNull(actual.Target.InterfaceDependency1);
            Assert.IsNotNull(actual.Target.InterfaceDependency2);
            Assert.IsNotNull(actual.Target.DbContextNoOptionsDependency);
            Assert.IsNotNull(actual.Target.DbContextWithOptionsDependency);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(5, actual.Dependencies.Keys.Count);
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(IMockInterface2)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(MockDbContextNoOptions)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(MockDbContextWithOptions)));
            Assert.IsTrue(actual.Dependencies.ContainsKey(typeof(Guid)));
            Assert.IsFalse(actual.Dependencies.ContainsKey(typeof(string)));
        }

        #endregion
    }
}