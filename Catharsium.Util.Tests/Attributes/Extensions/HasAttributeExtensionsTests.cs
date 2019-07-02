using System.ComponentModel.DataAnnotations;
using Catharsium.Util.Attributes;
using Catharsium.Util.Attributes.Extensions;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Attributes
{
    [TestClass]
    public class HasAttributeExtensionsTests
    {
        #region HasAttribute<T>(subject)

        [TestMethod]
        public void HasAttribute_ObjectWithAttribute_ReturnsTrue()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.HasAttribute<DisplayAttribute>();
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void HasAttribute_ObjectWithDifferentAttribute_ReturnsTrue()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.HasAttribute<AliasAttribute>();
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void HasAttribute_ObjectWithoutAttribute_ReturnsFalse()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.HasAttribute<AliasAttribute>();
            Assert.IsFalse(actual);
        }

        #endregion

        #region HasAttribute<T>(subject, memberName)

        [TestMethod]
        public void HasAttribute_MethodWithAttribute_ReturnsTrue()
        {
            var subject = new MockMethod();
            var actual = subject.HasAttribute<AliasAttribute>("MethodWithAlias");
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void HasAttribute_MethodWithDifferentAttribute_ReturnsTrue()
        {
            var subject = new MockMethod();
            var actual = subject.HasAttribute<DisplayAttribute>("MethodWithAlias");
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void HasAttribute_MethodWithoutAttribute_ReturnsFalse()
        {
            var subject = new MockMethod();
            var actual = subject.HasAttribute<AliasAttribute>("MethodWithoutAlias");
            Assert.IsFalse(actual);
        }

        #endregion
    }
}