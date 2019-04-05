using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.ParameterSubstituteFactoryTests
{
    [TestClass]
    public class GetSubstituteTests
    {
        #region Fixture

        protected ParameterSubstituteFactory Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new ParameterSubstituteFactory();
        }

        #endregion

        [TestMethod]
        public void GetSubstitute_Interface_ReturnsSubstitute()
        {
            var actual = this.Target.GetSubstitute<IMockInterface1>();
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void GetSubstitute_DbContext_ReturnsSubstitute()
        {
            var actual = this.Target.GetSubstitute<MockDbContext>();
            Assert.IsNotNull(actual);
        }
    }
}