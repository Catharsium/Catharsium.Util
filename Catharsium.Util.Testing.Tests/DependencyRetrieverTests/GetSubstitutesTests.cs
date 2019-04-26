using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.DependencyRetrieverTests
{
    [TestClass]
    public class GetSubstitutesTests
    {
        #region Fixture

        private ISubstituteFactory SubstituteFactory { get; set; }

        public DependencyRetriever Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.SubstituteFactory = Substitute.For<ISubstituteFactory>();
            this.Target = new DependencyRetriever(this.SubstituteFactory);
        }

        #endregion

        #region GetDependencySubstitutes

        [TestMethod]
        public void GetSubstitutes_MultipleDependencies_ReturnsSubstitutesForEach()
        {
            var dependencies = new List<Type> {
                typeof(IMockInterface1),
                typeof(IMockInterface2)
            };

            var actual = this.Target.GetSubstitutes(dependencies);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }


        [TestMethod]
        public void GetDependencySubstitutes_NoDependencies_ReturnsEmptyDictonary()
        {
            var actual = this.Target.GetSubstitutes(new List<Type>());
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }

        #endregion
    }
}