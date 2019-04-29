using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class DbContextSubstituteFactoryTests
    {
        #region Fixture


        private IConstructorFilter ConstructorFilter { get; set; }

        protected DbContextSubstituteFactory Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.ConstructorFilter = Substitute.For<IConstructorFilter>();
            this.Target = new DbContextSubstituteFactory(this.ConstructorFilter);
        }

        #endregion

        #region CreateDbContextSubstitute

        [TestMethod]
        public void CreateDbContextSubstitute_NoOptions()
        {
            var type = typeof(MockDbContextNoOptions);
            this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns(new[] { type.GetConstructors().First() });
            var actual = this.Target.CreateDbContextSubstitute(type);
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(MockDbContextNoOptions), actual.GetType());
        }


        [TestMethod]
        public void CreateDbContextSubstitute_WithOptions()
        {
            var type = typeof(MockDbContextWithOptions);
            this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns(new[] { type.GetConstructors().First() });
            var actual = this.Target.CreateDbContextSubstitute(type);
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(MockDbContextWithOptions), actual.GetType());
        }

        #endregion
    }
}