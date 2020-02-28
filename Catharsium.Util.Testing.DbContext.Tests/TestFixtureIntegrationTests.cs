using Catharsium.Util.Testing.DbContext._Configuration;
using Catharsium.Util.Testing.DbContext.Tests.Mocks;
using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.DbContext.Tests
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
            Assert.AreEqual(2, actual.Dependencies.Count);
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
            Assert.AreEqual(2, actual.Dependencies.Count);
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_ConstructorWithoutInterfacesDependencies()
        {
            var actual = new TestFixture<MockObjectWithoutInterfaces>();
            Assert.IsNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(0, actual.Dependencies.Count);
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
            Assert.AreEqual(2, actual.Dependencies.Count);
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
            Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
        }


        [TestMethod]
        public void TestFixture_WorksWith_AllSupportedDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDatabaseTestingUtilities<MockDbContextNoOptions>();
            serviceCollection.AddDatabaseTestingUtilities<MockDbContextWithOptions>();
            serviceCollection.AddDatabaseTestingUtilities<MockDbContextWithTypedOptions>();

            var actual = new TestFixture<MockObjectWithDbContextDependencies>(serviceCollection);
            Assert.IsNotNull(actual.Target);
            Assert.IsNull(actual.Target.InterfaceDependency1);
            Assert.IsNotNull(actual.Target.InterfaceDependency2);
            Assert.IsNotNull(actual.Target.DbContextNoOptionsDependency);
            Assert.IsNotNull(actual.Target.DbContextWithOptionsDependency);
            Assert.IsNotNull(actual.Dependencies);
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface1)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(IMockInterface2)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextNoOptions)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextWithOptions)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(MockDbContextWithTypedOptions)));
            Assert.IsTrue(Contains(actual.Dependencies, typeof(Guid)));
            Assert.IsFalse(Contains(actual.Dependencies, typeof(string)));
        }

        #endregion

        private static bool Contains(IEnumerable<Dependency> dependencies, Type type, string name = null, object value = null)
        {
            var dependency = dependencies.FirstOrDefault(d => d.Type == type && (name == null || d.Name == name));
            if (dependency == null) {
                return false;
            }

            if (value != null) {
                return dependency.Value == value;
            }

            return dependency.Value != null;
        }
    }
}