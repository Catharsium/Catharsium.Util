using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class GetEligibleConstructorIEnumerableTests
    {
        #region Fixture

        private List<Type> Dependencies { get; set; }

        private ConstructorFilter<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Dependencies = new List<Type>();
            this.Target = new ConstructorFilter<MockObject>();
        }

        #endregion

        #region GetEligibleConstructors

        [TestMethod]
        public void GetEligibleConstructors_WithSingleConstructorSatisfied_ReturnsSingleConstructor()
        {
            this.Dependencies.Add(typeof(IMockInterface1));
            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(1, actualList.Count);
            Assert.AreEqual(1, actualList[0].GetParameters().Length);
            Assert.AreEqual(typeof(IMockInterface1), actualList[0].GetParameters()[0].ParameterType);
        }


        [TestMethod]
        public void GetEligibleConstructors_WithAllInterfacesConstructorSatisfied_ReturnsAllInterfaceConstructors()
        {
            this.Dependencies.Add(typeof(IMockInterface1));
            this.Dependencies.Add(typeof(IMockInterface2));

            var actual = this.Target.GetEligibleConstructors(this.Dependencies);
            var actualList = actual.ToList();
            Assert.AreEqual(2, actualList.Count);
            AssertOnlyConstructurWithOnlyInterfaces(actualList);
        }


        [TestMethod]
        public void GetEligibleConstructors_WithDependencyFromIneligibleConstructor_IncludesConstructor()
        {
            this.Dependencies.Add(typeof(IMockInterface1));
            this.Dependencies.Add(typeof(IMockInterface2));
            this.Dependencies.Add(typeof(string));

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