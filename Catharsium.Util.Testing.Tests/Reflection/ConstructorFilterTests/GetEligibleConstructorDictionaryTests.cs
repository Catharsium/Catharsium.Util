using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class GetEligibleConstructorTests
    {
        #region Fixture

        private Type Type { get; set; }

        private Dictionary<Type, object> Dependencies { get; set; }

        private ConstructorFilter Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Type = typeof(MockObject);
            this.Dependencies = new Dictionary<Type, object>();
            this.Target = new ConstructorFilter(new Type[0]);
        }

        #endregion

        #region GetEligibleConstructors(Dictionary)

        [TestMethod]
        public void GetEligibleConstructors_ReturnsGetEligibleConstructorsIEnumerable()
        {
            this.Dependencies[typeof(IMockInterface1)] = Substitute.For<IMockInterface1>();
            var expected = this.Target.GetEligibleConstructors(this.Type, this.Dependencies.Keys);

            var actual = this.Target.GetEligibleConstructors(this.Type, this.Dependencies);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            foreach(var constructor in expected)
            {
                Assert.IsTrue(actual.Contains(constructor));
            }
        }

        
        [TestMethod]
        public void GetEligibleConstructors_EmptyDictionary_ReturnsGetEligibleConstructorsIEnumerable()
        {
            var expected = this.Target.GetEligibleConstructors(this.Type, this.Dependencies.Keys);
            var actual = this.Target.GetEligibleConstructors(this.Type, null as Dictionary<Type, object>);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            foreach (var constructor in expected)
            {
                Assert.IsTrue(actual.Contains(constructor));
            }
        }

        #endregion
    }
}