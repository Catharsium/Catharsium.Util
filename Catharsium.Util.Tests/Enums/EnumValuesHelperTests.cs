using System;
using System.Linq;
using Catharsium.Util.Enums;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Enums
{
    [TestClass]
    public class EnumValuesHelperTests
    {
        [TestMethod]
        public void GetValues_ReturnsEnumValues()
        {
            var actual = EnumValuesHelper.GetValues<MockEnum>().ToArray();
            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual(MockEnum.First, actual[0]);
            Assert.AreEqual(MockEnum.Second, actual[1]);
            Assert.AreEqual(MockEnum.WithAlias, actual[2]);
            Assert.AreEqual(MockEnum.WithoutAlias, actual[3]);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValues_NotAnEnum_ThrowsException()
        {
            EnumValuesHelper.GetValues<int>();
        }
    }
}