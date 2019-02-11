using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class CreateTargetTests
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
            Assert.IsNotNull(actual.InterfaceDependency1);
            Assert.IsNotNull(actual.InterfaceDependency2);
            Assert.IsNull(actual.StringDependency);
        }


        [TestMethod]
        public void CreateTarget_WithSingleInterfaceDependency_ReturnsTargetWithSingleInterfaceFilled()
        {
            var dependency1 = Substitute.For<IMockInterface1>();
            this.Dependencies[typeof(IMockInterface1)] = dependency1;

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.InterfaceDependency1);
            Assert.IsNull(actual.InterfaceDependency2);
            Assert.IsNull(actual.StringDependency);
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
    }



    [TestClass]
    public class TestFactoryWithoutInterfacesTests
    {
        #region Fixture

        private Dictionary<Type, object> Dependencies { get; set; }

        private TargetFactory<MockObjectWithoutInterfaces> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Dependencies = new Dictionary<Type, object>();
            this.Target = new TargetFactory<MockObjectWithoutInterfaces>();
        }

        #endregion

        #region CreateTarget

        [TestMethod]
        public void CreateTarget_CorrectDependency_ReturnsTarget()
        {
            var expected = "My string";
            this.Dependencies[typeof(string)] = expected;
            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.StringDependency);
        }


        [TestMethod]
        public void CreateTarget_WrongDependency_ReturnsNull()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
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
    }
}
