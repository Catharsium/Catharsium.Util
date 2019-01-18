using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.TargetFactoryTests
{
    [TestClass]
    public class GetDependencySubstitutesTests
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

        [TestMethod]
        public void GetDependencySubstitutes_ConstructorWithInterfaceDependencies_ReturnsSubstitutes()
        {
            var constructor = typeof(MockObject).GetConstructors().OrderBy(c => c.GetParameters().Length).ToList()[1];
            var actual = this.Target.GetDependencySubstitutes(constructor);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(actual.ContainsKey(typeof(IMockInterface2)));
        }
    }
}
