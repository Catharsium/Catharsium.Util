using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class GetLargestEligibleConstructorTests
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
    }
}