using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class TargetFactoryTests
    {
        #region Fixture

        private Type Type { get; set; }
        private Dictionary<Type, object> Dependencies { get; set; }
        protected IConstructorFilter ConstructorFilter { get; set; }
        protected TargetFactory<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Type = typeof(MockObject);
            this.Dependencies = new Dictionary<Type, object>();
            this.ConstructorFilter = Substitute.For<IConstructorFilter>();
            this.Target = new TargetFactory<MockObject>(this.ConstructorFilter);
        }

        #endregion

        #region CreateTarget

        [TestMethod]
        public void CreateTarget_WithAllInterfaceDependencies_ReturnsTargetWithInterfacesFilled()
        {
            var dependency1Type = typeof(IMockInterface1);
            var dependency2Type = typeof(IMockInterface2);
            this.Dependencies[dependency1Type] = Substitute.For<IMockInterface1>();
            this.Dependencies[dependency2Type] = Substitute.For<IMockInterface2>();
            var constructor = this.Type.GetConstructor(new[] { dependency1Type, dependency2Type });
            this.ConstructorFilter.GetLargestEligibleConstructor(this.Type, this.Dependencies).Returns(constructor);

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.InterfaceDependency1);
            Assert.IsNotNull(actual.InterfaceDependency2);
            Assert.IsNull(actual.StringDependency);
        }


        [TestMethod]
        public void CreateTarget_WithTooFewDependencies_ReturnsNull()
        {
            this.Dependencies[typeof(IMockInterface2)] = Substitute.For<IMockInterface2>();
            var constructor = this.Type.GetConstructor(new[] { typeof(IMockInterface1), typeof(IMockInterface2) });
            this.ConstructorFilter.GetLargestEligibleConstructor(this.Type).Returns(constructor);

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void CreateTarget_WithTooManyDependencies_ReturnsTargetWithInterfacesFilled()
        {
            var dependency1Type = typeof(IMockInterface1);
            var dependency2Type = typeof(IMockInterface2);
            this.Dependencies[dependency1Type] = Substitute.For<IMockInterface1>();
            this.Dependencies[dependency2Type] = Substitute.For<IMockInterface2>();
            var constructor = this.Type.GetConstructor(new[] { dependency1Type });
            this.ConstructorFilter.GetLargestEligibleConstructor(this.Type, this.Dependencies).Returns(constructor);

            var actual = this.Target.CreateTarget(this.Dependencies);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.InterfaceDependency1);
            Assert.IsNull(actual.InterfaceDependency2);
            Assert.IsNull(actual.StringDependency);
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