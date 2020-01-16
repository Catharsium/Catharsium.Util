using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class SubstituteFactoryTests
    {
        #region Fixture

        protected ISubstituteFactory SubstituteFactory;
        protected SubstituteService Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.SubstituteFactory = Substitute.For<ISubstituteFactory>();
            this.Target = new SubstituteService(new [] {this.SubstituteFactory});
        }

        #endregion

        [TestMethod]
        public void GetSubstitute_Interface_ReturnsSubstitute()
        {
            var type = typeof(IMockInterface1);
            var actual = this.Target.GetSubstitute(type);
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void GetSubstitute_Guid_ReturnsSubstitute()
        {
            var type = typeof(Guid);
            var actual = this.Target.GetSubstitute(typeof(Guid));
            Assert.IsNotNull(actual);
            Assert.AreEqual(type, actual.GetType());
        }


        [TestMethod]
        public void GetSubstitute_DbContextNoOptions_ReturnsSubstitute()
        {
            var expected = new MockDbContextNoOptions();
            var type = expected.GetType();
            this.SubstituteFactory.CanCreateFor(type).Returns(true);
            this.SubstituteFactory.CreateSubstitute<MockDbContextNoOptions>(type).Returns(expected);

            var actual = this.Target.GetSubstitute(type);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetSubstitute_DbContextWithOptions_ReturnsSubstitute()
        {
            var expected = new MockDbContextWithOptions(new DbContextOptionsBuilder().Options);
            var type = expected.GetType();
            this.SubstituteFactory.CanCreateFor(type).Returns(true);
            this.SubstituteFactory.CreateSubstitute<MockDbContextWithOptions>(type).Returns(expected);

            var actual = this.Target.GetSubstitute(type);
            Assert.IsNotNull(actual);
        }
    }
}