using System;
using Catharsium.Util.Math.Lists;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Math.Tests.Lists
{
    [TestClass]
    public class ListMultiplicatorTests : TestFixture<ListMultiplicator>
    {
        [TestMethod]
        public void Multiply_NoNumbers_Returns0()
        {
            var input = Array.Empty<int>();
            var actual = this.Target.Multiply(input);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void Multiply_SingleNumber_ReturnsNumber()
        {
            var input = new[] { 1 };
            var actual = this.Target.Multiply(input);
            Assert.AreEqual(input[0], actual);
        }


        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsNumbersProduct()
        {
            var input = new[] { 2, 3 };
            var actual = this.Target.Multiply(input);
            Assert.AreEqual(input[0] * input[1], actual);
        }


        [TestMethod]
        public void Multiply_MultipleNumbers_ReturnsNumbersProduct()
        {
            var input = new[] { 4, 5, 6 };
            var actual = this.Target.Multiply(input);
            Assert.AreEqual(input[0] * input[1] * input[2], actual);
        }
    }
}