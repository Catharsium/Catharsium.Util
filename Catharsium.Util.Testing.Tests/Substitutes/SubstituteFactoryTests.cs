using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Substitutes;
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
            this.Target = new SubstituteService(new[] {this.SubstituteFactory});
        }

        #endregion

        [TestMethod]
        public void GetSubstitute_SupportedType_ReturnsSubstitute()
        {
            var expected = Guid.NewGuid();
            var type = expected.GetType();
            this.SubstituteFactory.CanCreateFor(type).Returns(true);
            this.SubstituteFactory.CreateSubstitute(type).Returns(expected);

            var actual = this.Target.GetSubstitute(type);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetSubstitute_UnsupportedType_ReturnsSubstitute()
        {
            var expected = Guid.NewGuid();
            var type = expected.GetType();
            this.SubstituteFactory.CanCreateFor(type).Returns(false);

            var actual = this.Target.GetSubstitute(type);
            Assert.IsNull(actual);
        }
    }
}