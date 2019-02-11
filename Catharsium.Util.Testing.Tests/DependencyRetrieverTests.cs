using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class DependencyRetrieverTests
    {
        #region Fixture

        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new DependencyRetriever();
        }

        #endregion

        #region GetDependencies

        [TestMethod]
        public void GetDependencies_NoDependencies_ReturnsEmptyList()
        {
            var actual = this.Target.GetDependencies<object>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }


        [TestMethod]
        public void GetDependencies_ConstructorWithAllDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObject>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Contains(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencies_MultipleConstructorsWithDifferentDependencies_ReturnsAllDependencies()
        {
            var actual = this.Target.GetDependencies<MockObjectWithDifferentDependencies>().ToList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(typeof(IMockInterface1)));
            Assert.IsTrue(actual.Contains(typeof(IMockInterface2)));
        }

        #endregion

        #region GetDependencySubstitutes

        //public Dictionary<Type, object> GetDependencySubstitutes(IEnumerable<Type> dependencies)
        //{
        //    var result = new Dictionary<Type, object>();

        //    foreach (var dependency in dependencies) {
        //        var substitute = Substitute.For(new[] { dependency }, Array.Empty<object>());
        //        result.Add(dependency, substitute);
        //    }

        //    return result;
        //}

        #endregion


        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithInterfaceDependencies_ReturnsSubstitutes()
        {
            var constructor = typeof(MockObject).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList()[1];
            var dependencies = new Dictionary<Type, object>
            {
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
    }
}