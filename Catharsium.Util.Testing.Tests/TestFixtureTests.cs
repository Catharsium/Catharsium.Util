using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class TestFixtureTests
    {
        #region Fixture

        public Dictionary<Type, object> ExpectedDependencies { get; private set; }

        public MockObject ExpectedTarget { get; private set; }

        private IDependencyRetriever DependencyRetriever { get; set; }

        private ITargetFactory<MockObject> TargetFactory { get; set; }

        private TestFixture<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.DependencyRetriever = Substitute.For<IDependencyRetriever>();
            this.ExpectedDependencies = new Dictionary<Type, object>();
            var constructorInfo = Substitute.For<ConstructorInfo>();
            this.DependencyRetriever.GetDependencySubstitutes(constructorInfo).Returns(this.ExpectedDependencies);

            this.TargetFactory = Substitute.For<ITargetFactory<MockObject>>();
            this.TargetFactory.GetLargestEligibleConstructor().Returns(constructorInfo);
            this.ExpectedTarget = new MockObject(null);
            this.TargetFactory.CreateTarget(this.ExpectedDependencies).Returns(this.ExpectedTarget);
            this.Target = new TestFixture<MockObject>(this.DependencyRetriever, this.TargetFactory);
        }

        #endregion

        #region Constructor
        
        [TestMethod]
        public void Constructor_ObtainsInitialConstruct_StoresDependenciesAndTarget()
        {
            var actual = new TestFixture<MockObject>(this.DependencyRetriever, this.TargetFactory);
            Assert.IsNotNull(actual.Target);
            Assert.AreEqual(this.ExpectedTarget, actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(this.ExpectedDependencies, actual.Dependencies);
        }


        [TestMethod]
        public void Constructor_NoSuitableConstructor_StoresNoDependenciesNorTarget()
        {
            var constructor = Substitute.For<ConstructorInfo>();
            var dependencyRetriever = Substitute.For<IDependencyRetriever>();
            var expectedDependencies = new Dictionary<Type, object>();
            dependencyRetriever.GetDependencySubstitutes<MockObject>().Returns(expectedDependencies);
            dependencyRetriever.GetDependencySubstitutes(constructor);

            var targetFactory = Substitute.For<ITargetFactory<MockObjectWithoutInterfaces>>();
            targetFactory.GetLargestEligibleConstructor().Returns(constructor);
            targetFactory.CreateTarget(this.ExpectedDependencies).Returns(null as MockObjectWithoutInterfaces);

            var actual = new TestFixture<MockObjectWithoutInterfaces>(dependencyRetriever, targetFactory);
            Assert.IsNull(actual.Target);
            Assert.IsNotNull(actual.Dependencies);
            Assert.AreEqual(expectedDependencies, actual.Dependencies);
        }
        #endregion

        #region GetDependency

        [TestMethod]
        public void GetDependency_ValidType_ReturnsDependency()
        {
            var expected = "";
            this.Target.Dependencies[typeof(string)] = expected;
            var actual = this.Target.GetDependency<string>();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetDependency_InvalidType_ReturnsNull()
        {
            var actual = this.Target.GetDependency<string>();
            Assert.IsNull(actual);
        }

        #endregion

        #region SetDependency

        [TestMethod]
        public void SetDependency_NewDependency_IsAddedToDependenciesList()
        {
            var expected = "My string";
            this.ExpectedDependencies[typeof(string)] = expected;
            this.TargetFactory.CreateTarget(this.ExpectedDependencies).Returns(this.ExpectedTarget);
            this.Target = new TestFixture<MockObject>(this.DependencyRetriever, this.TargetFactory);

            this.Target.SetDependency(expected);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(expected.GetType()));
            Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
        }
        
        
        [TestMethod]
        public void SetDependency_ExistingDependency_ReplacesCurrentInDependenciesList()
        {
            var expected = Substitute.For<IMockInterface1>();
            var type = typeof(IMockInterface1);
            this.Target.SetDependency(expected);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(type));
            Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
        }


        [TestMethod]
        public void SetDependency_DependencyInMostSpecificConstructor_NewTargetWithDependencyAndAllInterfacesSatisfied()
        {
            var expected = "My string";
            this.Target.SetDependency(expected);
            Assert.AreEqual(this.ExpectedTarget, this.Target.Target);
        }

        #endregion

        #region Support Methods

        private static List<ConstructorInfo> GetConstructors<T>()
        {
            return typeof(T).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList();
        }

        #endregion
    }
}