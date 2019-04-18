using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class DbContextSubstituteFactoryTests
    {
        #region Fixture

        protected DbContextSubstituteFactory Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new DbContextSubstituteFactory();
        }

        #endregion

        #region CreateDbContextSubstitute

        [TestMethod]
        public void CreateDbContextSubstitute_NoOptions()
        {
            var actual = this.Target.CreateDbContextSubstitute<MockDbContextNoOptions>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(MockDbContextNoOptions), actual.GetType());
        }


        [TestMethod]
        public void CreateDbContextSubstitute_WithOptions()
        {
            var actual = this.Target.CreateDbContextSubstitute<MockDbContextWithOptions>();
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(MockDbContextWithOptions), actual.GetType());
        }

        #endregion
    }
}