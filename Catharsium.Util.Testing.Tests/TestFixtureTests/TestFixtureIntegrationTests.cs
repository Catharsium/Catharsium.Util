using System;
using System.Collections.Generic;
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
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
            Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_SingleConstructor()
        {
            var actual = new TestFixture<MockObjectWithSingleConstructor>();
            Assert.IsNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(2, actual.Dependencies.Keys.Count);
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
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
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
            Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
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
            Assert.AreEqual(6, actual.Dependencies.Keys.Count);
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextNoOptions)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextWithOptions)));
            //Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextWithTypedOptions)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(Guid)));
            Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
        }

        #endregion

        private static bool Contains(IReadOnlyDictionary<Type, object> dependencies, Type type, object value = null)
        {
            var containsKey = dependencies.ContainsKey(type);
            if (!containsKey) {
                return false;
            }
            if (value != null) {
                return dependencies[type] != value;
            }

            return dependencies[type] != null;
        }
    }
}