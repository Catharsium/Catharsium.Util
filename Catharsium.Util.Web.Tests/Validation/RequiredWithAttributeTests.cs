using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Catharsium.Util.Testing;
using Catharsium.Util.Web.Tests._Mocks;
using Catharsium.Util.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Web.Tests.Validation
{
    [TestClass]
    public class RequiredWithAttributeTests : TestFixture<RequiredWithAttribute>
    {
        #region Validator.TryValidateObject

        [TestMethod]
        public void IsValid_ValidModel_ReturnsTrue()
        {
            var mockObject = new MockObjectWithRequiredWithValidation {
                Property1 = "1",
                Property2 = "2"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_ValueEmpty_ReturnsFalse()
        {
            var mockObject = new MockObjectWithRequiredWithValidation {
                Property1 = "1"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_OtherValueEmpty_ReturnsFalse()
        {
            var mockObject = new MockObjectWithRequiredWithValidation {
                Property2 = "2"
            };
            var validationContext = new ValidationContext(mockObject);

            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
            Assert.IsFalse(actual);
        }

        #endregion

        #region IsValid

        [TestMethod]
        public void IsValid_WithValue_OtherPropertyIsEmpty_ReturnsFalse()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation();
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_OtherPropertyHasValue_ReturnsTrue()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation {
                Property2 = "My property 2"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_MultipleOtherPropertiesWithValue_ReturnsTrue()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation {
                Property2 = "My property 2",
                Property3 = "My property 3"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2), nameof(MockObjectWithOneInGroupRequiredValidation.Property3));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_MultipleOtherPropertiesOneWithoutValue_ReturnsTrue()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation {
                Property3 = "My property 3"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2), nameof(MockObjectWithOneInGroupRequiredValidation.Property3));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_WithoutValue_ReturnsTrue()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation();
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2));

            var actual = this.Target.IsValid("", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_NullValue_ReturnsTrue()
        {
            var mockObject = new MockObjectWithOneInGroupRequiredValidation();
            this.Target = new RequiredWithAttribute(nameof(MockObjectWithOneInGroupRequiredValidation.Property2));

            var actual = this.Target.IsValid(null, mockObject);
            Assert.IsTrue(actual);
        }

        #endregion
    }
}