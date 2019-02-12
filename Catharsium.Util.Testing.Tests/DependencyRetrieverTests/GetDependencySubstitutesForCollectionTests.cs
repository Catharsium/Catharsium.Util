using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.DependencyRetrieverTests
{
    [TestClass]
    public class GetDependencySubstitutesForCollectionTests
    {
        #region Fixture

        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new DependencyRetriever();
        }

        #endregion

        #region GetDependencySubstitutes

        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithInterfaceDependencies_ReturnsSubstitutes()
        {
            var constructor = typeof(MockObject).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList()[1];
            var dependencies = new Dictionary<Type, object> {
                [typeof(IMockInterface1)] = Substitute.For<IMockInterface1>(),
                [typeof(IMockInterface2)] = Substitute.For<IMockInterface2>()
            };
            var actual = this.Target.GetDependencySubstitutes(constructor, dependencies);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.AreEqual(dependencies[typeof(IMockInterface1)], actual[typeof(IMockInterface1)]);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
            Assert.AreEqual(dependencies[typeof(IMockInterface2)], actual[typeof(IMockInterface2)]);
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