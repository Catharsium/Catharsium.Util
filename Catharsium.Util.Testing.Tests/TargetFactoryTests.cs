using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class TargetFactoryTests
    {
        #region Fixture

        private Dictionary<Type, object> Dependencies { get; set; }

        private TargetFactory<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Dependencies = new Dictionary<Type, object>();
            this.Target = new TargetFactory<MockObject>();
        }

        #endregion

        #region CreateTarget

        [TestMethod]
        public void CreateTarget_WithAllInterfaceDependencies_ReturnsTargetWithInterfacesFilled()
        {
            var dependency1 = Substitute.For<IMockInterface1>();
            var dependency2 = Substitute.For<IMockInterface2>();
            this.Dependencies[typeof(IMockInterface1)] = dependency1;
            this.Dependencies[typeof(IMockInterface2)] = dependency2;

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.interfaceDependency1);
            Assert.IsNotNull(actual.interfaceDependency2);
            Assert.IsNull(actual.stringDependency);
        }

        
        [TestMethod]
        public void CreateTarget_WithSingleInterfaceDependency_ReturnsTargetWithSingleInterfaceFilled()
        {
            var dependency1 = Substitute.For<IMockInterface1>();
            this.Dependencies[typeof(IMockInterface1)] = dependency1;

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.interfaceDependency1);
            Assert.IsNull(actual.interfaceDependency2);
            Assert.IsNull(actual.stringDependency);
        }


        [TestMethod]
        public void CreateTarget_WithTooFewDependencies_ReturnsNull()
        {
            var dependency1 = Substitute.For<IMockInterface2>();
            this.Dependencies[typeof(IMockInterface2)] = dependency1;

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void CreateTarget_NoDependencies_ReturnsNull()
        {
            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNull(actual);
        }

        #endregion

        #region GetLargestEligibleConstructor

        [TestMethod]
        public void GetLargestEligibleConstructor_NoDependencies_ReturnsLargestConstructorWithOnlyInterfaces()
        {
            var actual = this.Target.GetLargestEligibleConstructor(this.Dependencies);
            Assert.AreEqual(2, actual.GetParameters().Length);
        }


        [TestMethod]
        public void GetLargestEligibleConstructor_WithDependenciesFromLargestConstructor_ReturnsLargestConstructor()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
            this.Dependencies[typeof(IMockInterface2)] = Substitute.For<IMockInterface2>();
            this.Dependencies[typeof(string)] = "My string";

            var actual = this.Target.GetLargestEligibleConstructor(this.Dependencies);
            Assert.AreEqual(3, actual.GetParameters().Length);
        }

        #endregion

        #region GetEligibleConstructors

        [TestMethod]
        public void GetEligibleConstructors_WithSingleConstructorSatisfied_ReturnsSingleConstructor()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(1, actualList.Count);
            Assert.AreEqual(1, actualList[0].GetParameters().Length);
            Assert.AreEqual(typeof(IMockInterface1), actualList[0].GetParameters()[0].ParameterType);
        }


        [TestMethod]
        public void GetEligibleConstructors_WithAllInterfacesConstructorSatisfied_ReturnsAllInterfaceConstructors()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
            this.Dependencies[typeof(IMockInterface2)] = Substitute.For<IMockInterface2>();

            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(2, actualList.Count);
            AssertOnlyConstructurWithOnlyInterfaces(actualList);
        }


        [TestMethod]
        public void GetEligibleConstructors_WithDependencyFromIneligibleConstructor_IncludesConstructor()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
            this.Dependencies[typeof(IMockInterface2)] = Substitute.For<IMockInterface2>();
            this.Dependencies[typeof(string)] = "My string";

            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(3, actualList.Count);
        }


        [TestMethod]
        public void GetEligibleConstructors_NoDependencies_ReturnsConstructorsThatOnlyRequireInterfaces()
        {
            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(2, actualList.Count);
        }

        #endregion

        #region Support Methods
        
        private static void AssertOnlyConstructurWithOnlyInterfaces(IEnumerable<ConstructorInfo> constructors)
        {
            foreach (var actualConstructor in constructors)
            {
                var parameters = actualConstructor.GetParameters();
                foreach (var parameter in parameters)
                {
                    Assert.IsTrue(parameter.ParameterType.IsInterface);
                }
            }
        }

        #endregion
    }
}
