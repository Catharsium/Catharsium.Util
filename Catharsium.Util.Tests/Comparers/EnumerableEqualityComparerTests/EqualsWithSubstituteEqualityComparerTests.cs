using System;
using System.Collections.Generic;
using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Comparers
{
    [TestClass]
    public class EqualsWithSubstituteEqualityComparerTests : TestFixture<EnumerableEqualityComparer<string>>
    {
        #region Fixture

        [TestInitialize]
        public void SetupDependencies()
        {
            this.GetDependency<IEqualityComparer<string>>()
                .Equals(Arg.Any<string>(), Arg.Any<string>())
                .Returns(x => { return x[0] == x[1]; });
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_IsReflexive()
        {
            var input = new List<string>() { "a" };
            var actual = this.Target.Equals(input, input);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_IsSymmetric()
        {
            var input1 = new List<string> { "a", "b", "c" };
            var input2 = new List<string> { "a", "b", "c" };

            var actual = this.Target.Equals(input1, input2);
            var actualReverse = this.Target.Equals(input2, input1);
            Assert.AreEqual(actual, actualReverse);
        }


        [TestMethod]
        public void Equals_EmptyListAndEmptyList_ReturnsTrue()
        {
            var input1 = new List<string>();
            var input2 = new List<string>();

            var actual = this.Target.Equals(input1, input2);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_ListsWithSameContents_ReturnsTrue()
        {
            var input1 = new List<string>() { "a", "b", "c" };
            var input2 = new List<string>();
            input2.AddRange(input1);

            var actual = this.Target.Equals(input1, input2);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_ListWithDifferentContents_ReturnsFalse()
        {
            var input1 = new List<string>() { "a" };
            var input2 = new List<string>() { "b" };

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_DifferentLengthLists_ReturnsFalse()
        {
            var input1 = new List<string>() { "a", "b", "c" };
            var input2 = new List<string>() { "" };
            input2.AddRange(input1);

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_NullListAndList_ReturnsFalse()
        {
            List<string> input1 = null;
            var input2 = new List<string>();

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_ListAndNullList_ReturnsFalse()
        {
            var input1 = new List<string>();
            List<string> input2 = null;

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }

        #endregion

        #region GetHashCode

        [TestMethod]
        public void GetHashCode_ReturnsObjectHashcode()
        {
            var input = Array.Empty<string>();
            var actual = this.Target.GetHashCode(input);
            Assert.AreEqual(input.GetHashCode(), actual);
        }

        #endregion
    }
}