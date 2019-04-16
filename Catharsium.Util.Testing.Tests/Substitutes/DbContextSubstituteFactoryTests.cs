using Catharsium.Util.Testing.Substitutes;
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
    }
}