﻿using System;
using System.Collections.Generic;
using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Comparers
{
    [TestClass]
    public class EqualsWithDefaultEqualityComparerTests : TestFixture<EnumerableEqualityComparer<int>>
    {
        #region Fixture

        [TestInitialize]
        public void SetupDependencies()
        {
            this.SetDependency<IEqualityComparer<int>>(null);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_IsReflexive()
        {
            var input = new List<int>() { 1, 2, 3 };
            var actual = this.Target.Equals(input, input);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_IsSymmetric()
        {
            var input1 = new List<int> { 1, 2, 3 };
            var input2 = new List<int> { 1, 2, 3 };

            var actual = this.Target.Equals(input1, input2);
            var actualReverse = this.Target.Equals(input2, input1);
            Assert.AreEqual(actual, actualReverse);
        }


        [TestMethod]
        public void Equals_EmptyListAndEmptyList_ReturnsTrue()
        {
            var input1 = new List<int>();
            var input2 = new List<int>();

            var actual = this.Target.Equals(input1, input2);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_ListsWithSameContents_ReturnsTrue()
        {
            var input1 = new List<int>() { 1, 2, 3 };
            var input2 = new List<int>();
            input2.AddRange(input1);

            var actual = this.Target.Equals(input1, input2);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_ListWithDifferentContents_ReturnsFalse()
        {
            var input1 = new List<int>() { 1 };
            var input2 = new List<int>() { 2 };

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_DifferentLengthLists_ReturnsFalse()
        {
            var input1 = new List<int>() { 1, 2, 3 };
            var input2 = new List<int>() { 0 };
            input2.AddRange(input1);

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_NullListAndList_ReturnsFalse()
        {
            List<int> input1 = null;
            var input2 = new List<int>();

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_ListAndNullList_ReturnsFalse()
        {
            var input1 = new List<int>();
            List<int> input2 = null;

            var actual = this.Target.Equals(input1, input2);
            Assert.IsFalse(actual);
        }

        #endregion

        #region GetHashCode

        [TestMethod]
        public void GetHashCode_ReturnsObjectHashcode()
        {
            var input = Array.Empty<int>();
            var actual = this.Target.GetHashCode(input);
            Assert.AreEqual(input.GetHashCode(), actual);
        }

        #endregion
    }
}