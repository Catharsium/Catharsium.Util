using Catharsium.Util.Testing.Databases.Substitutes;
using Catharsium.Util.Testing.Databases.Tests.Mocks;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Testing.Databases.Tests.Substitutes
{
    [TestClass]
    public class DbContextWithTypedOptionsSubstituteFactoryTests
    {
        #region Fixture

        private IConstructorFilter ConstructorFilter { get; set; }
        protected DbContextSubstituteFactory<MockDbContextWithTypedOptions> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.ConstructorFilter = Substitute.For<IConstructorFilter>();
            this.Target = new DbContextSubstituteFactory<MockDbContextWithTypedOptions>(this.ConstructorFilter);
        }

        #endregion

        #region CanCreateFor

        [TestMethod]
        public void CanCreateFor_DbContextType_ReturnsTrue()
        {
            var type = typeof(MockDbContextWithTypedOptions);
            this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns(type.GetConstructors());

            var actual = this.Target.CanCreateFor(type);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void CanCreateFor_NoDbContextType_ReturnsFalse()
        {
            var type = typeof(string);
            var actual = this.Target.CanCreateFor(type);
            Assert.IsFalse(actual);
        }

        #endregion

        #region CreateDbContextSubstitute

        [TestMethod]
        public void CreateDbContextSubstitute_WithTypedOptions_ReturnsInstance()
        {
            var type = typeof(MockDbContextWithTypedOptions);
            this.ConstructorFilter.GetEligibleConstructors(type, Arg.Any<List<Type>>()).Returns(new[] {type.GetConstructors().First()});
            var actual = this.Target.CreateSubstitute(type);
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(MockDbContextWithTypedOptions), actual.GetType());
        }

        #endregion
    }
}