using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Catharsium.Util.Testing;
using Catharsium.Util.Web.Tests._Mocks;
using Catharsium.Util.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Web.Tests.Validation
{
    [TestClass]
    public class BsnAttributeTests : TestFixture<BsnAttribute>
    {
        #region Validator.TryValidateObject

        [TestMethod]
        public void IsValid_ValidModel_ReturnsTrue()
        {
            var mockObject = new MockObjectWithBsn {
                Bsn = "123456782"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_InvalidModel_ReturnsFalse()
        {
            var mockObject = new MockObjectWithBsn {
                Bsn = "0"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResult.Count);
        }


        [TestMethod]
        public void IsValid_NotANumber_ReturnsFalse()
        {
            var mockObject = new MockObjectWithBsn {
                Bsn = "Not a number"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResult.Count);
        }

        #endregion

        #region IsValid

        [TestMethod]
        public void IsValid_ValidValue_ReturnsTrue()
        {
            var actual = this.Target.IsValid("111222333");
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_ValueWith7Digits_ReturnsFalse()
        {
            var actual = this.Target.IsValid("1234567");
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_ValueWith10Digits_ReturnsFalse()
        {
            var actual = this.Target.IsValid("1234567890");
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_ValueWithFailing11Check_ReturnsFalse()
        {
            var actual = this.Target.IsValid("123456783");
            Assert.IsFalse(actual);
        }

        #endregion
    }
}