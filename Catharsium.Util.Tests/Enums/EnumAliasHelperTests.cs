﻿using Catharsium.Util.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Catharsium.Util.Tests._Mocks;

namespace Catharsium.Util.Tests.Enums
{
    [TestClass]
    public class EnumAliasHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTo_NonEnumType_ThrowsException()
        {
            "1".ParseTo<int>();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseTo_NullAlias_ThrowsException()
        {
            (null as string).ParseTo<MockEnum>();
        }


        [TestMethod]
        public void ParseTo_ValidAlias_ReturnsEnumValue()
        {
            var actual = "1".ParseTo<MockEnum>();
            Assert.AreEqual(MockEnum.First, actual);
        }


        [TestMethod]
        public void ParseTo_ValidAlias_ReturnsCorrectValue()
        {
            var actual = "2".ParseTo<MockEnum>();
            Assert.AreEqual(MockEnum.Second, actual);
        }


        [TestMethod]
        public void ParseTo_InvalidAlias_ThrowsException()
        {
            var actual = "Other alias".ParseTo<MockEnum>();
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void ParseTo_Fallback_DoesNotOverruleAlias()
        {
            var actual = "2".ParseTo<MockEnum>("1");
            Assert.AreEqual(MockEnum.Second, actual);
        }


        [TestMethod]
        public void ParseTo_InvalidAlias_UsesFallback()
        {
            var actual = "Other alias".ParseTo<MockEnum>("2");
            Assert.AreEqual(MockEnum.Second, actual);
        }
    }
}