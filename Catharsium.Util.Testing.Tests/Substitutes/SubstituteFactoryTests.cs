using Catharsium.Util.Testing.Substitutes;
using Catharsium.Util.Testing.Tests._Mocks;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Substitutes
{
    [TestClass]
    public class SubstituteFactoryTests
    {
        #region Fixture

        protected SubstituteFactory Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new SubstituteFactory();
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
            var actual = this.Target.GetSubstitute<MockDbContextNoOptions>();
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void GetSubstitute_DbContextWithOptions_ReturnsSubstitute()
        {
            var actual = this.Target.GetSubstitute<MockDbContextWithOptions>();
            Assert.IsNotNull(actual);
        }
    }
}