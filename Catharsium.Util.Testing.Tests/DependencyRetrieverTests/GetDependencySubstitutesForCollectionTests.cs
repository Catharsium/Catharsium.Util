using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Models;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.Tests.DependencyRetrieverTests
{
    [TestClass]
    public class GetDependencySubstitutesForCollectionTests
    {
        #region Fixture

        private ISubstituteService SubstituteFactory { get; set; }
        private IEnumerable<Type> SupportedTypes { get; set; }
        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.SubstituteFactory = Substitute.For<ISubstituteService>();
            this.SupportedTypes = new List<Type> {
                typeof(Guid)
            };
            this.Target = new DependencyRetriever(this.SubstituteFactory, this.SupportedTypes);
        }

        #endregion

        #region GetDependencySubstitutes

        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithInterfaceDependencies_ReturnsSubstitutes()
        {
            var constructor = typeof(MockObject).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList()[1];
            var dependencies = new List<Dependency> {
                new Dependency(typeof(IMockInterface1), "interface1", Substitute.For<IMockInterface1>()),
                new Dependency(typeof(IMockInterface2), "interface2", Substitute.For<IMockInterface2>())
            };

            var actual = this.Target.GetDependencySubstitutes(constructor, dependencies);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            foreach (var dependency in actual) {
                Assert.IsTrue(dependencies.Any(d => d.Type == dependency.Type && d.Name == dependency.Name && d.Value == dependency.Value));
            }
        }


        [TestMethod]
        public void GetDependencySubstitutes_NullConstructor_ReturnsEmptySubstitutes()
        {
            var actual = this.Target.GetDependencySubstitutes(null, null);
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }

        #endregion
    }
}