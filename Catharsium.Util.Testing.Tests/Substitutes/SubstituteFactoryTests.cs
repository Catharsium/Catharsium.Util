using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class SubstituteFactoryTests
    {
        #region Fixture

        protected IDbContextSubstituteFactory DbContextSubstituteFactory;
        protected SubstituteFactory Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.DbContextSubstituteFactory = Substitute.For<IDbContextSubstituteFactory>();
            this.Target = new SubstituteFactory(this.DbContextSubstituteFactory);
        }

        #endregion

        [TestMethod]
        public void GetSubstitute_Interface_ReturnsSubstitute()
        {
            var actual = this.Target.GetSubstitute<IMockInterface1>();
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void GetSubstitute_DbContextNoOptions_ReturnsSubstitute()
        {
            var expected = new MockDbContextNoOptions();
            this.DbContextSubstituteFactory.CreateDbContextSubstitute<MockDbContextNoOptions>().Returns(expected);

            var actual = this.Target.GetSubstitute<MockDbContextNoOptions>();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetSubstitute_DbContextWithOptions_ReturnsSubstitute()
        {
            var expected = new MockDbContextWithOptions(new DbContextOptionsBuilder().Options);
            this.DbContextSubstituteFactory.CreateDbContextSubstitute<MockDbContextWithOptions>().Returns(expected);

            var actual = this.Target.GetSubstitute<MockDbContextWithOptions>();
            Assert.IsNotNull(actual);
        }
    }
}