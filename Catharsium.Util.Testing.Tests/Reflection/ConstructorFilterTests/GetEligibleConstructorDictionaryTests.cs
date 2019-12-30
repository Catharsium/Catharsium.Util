using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.Tests.Reflection.ConstructorFilterTests
{
    [TestClass]
    public class GetEligibleConstructorTests
    {
        #region Fixture

        private Type Type { get; set; }

        private List<Dependency> Dependencies { get; set; }

        private ConstructorFilter Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Type = typeof(MockObject);
            this.Dependencies = new List<Dependency>();
            this.Target = new ConstructorFilter(new Type[0]);
        }

        #endregion

        #region GetEligibleConstructors(Dictionary)

        [TestMethod]
        public void GetEligibleConstructors_ReturnsGetEligibleConstructorsIEnumerable()
        {
            this.Dependencies.Add(new Dependency(typeof(IMockInterface1), "interface1", Substitute.For<IMockInterface1>()));
            var expected = this.Target.GetEligibleConstructors(this.Type, this.Dependencies).ToList();

            var actual = this.Target.GetEligibleConstructors(this.Type, this.Dependencies).ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (var constructor in expected) {
                Assert.IsTrue(actual.Contains(constructor));
            }
        }


        [TestMethod]
        public void GetEligibleConstructors_EmptyDictionary_ReturnsGetEligibleConstructorsIEnumerable()
        {
            var expected = this.Target.GetEligibleConstructors(this.Type, this.Dependencies).ToList();
            var actual = this.Target.GetEligibleConstructors(this.Type, null as List<Dependency>).ToList();
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (var constructor in expected) {
                Assert.IsTrue(actual.Contains(constructor));
            }
        }

        #endregion
    }
}