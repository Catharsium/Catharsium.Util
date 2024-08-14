using Catharsium.Util.Testing;
using Catharsium.Util.Web.Tests._Mocks;
using Catharsium.Util.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Catharsium.Util.Web.Tests.Validation;

[TestClass]
public class OneInGroupRequiredAttributeTests : TestFixture<OneInGroupRequiredAttribute>
{
    #region Validator.TryValidateObject

    [TestMethod]
    public void IsValid_ValidModel_ReturnsTrue() {
        var mockObject = new MockObjectWithOneInGroupRequiredValidation {
            Property1 = "1",
            Property3 = "3"
        };
        var validationContext = new ValidationContext(mockObject);

        var validationResult = new List<ValidationResult>();
        var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void IsValid_SingleGroupWithoutValue_ReturnsFalse() {
        var mockObject = new MockObjectWithOneInGroupRequiredValidation {
            Property1 = "1"
        };
        var validationContext = new ValidationContext(mockObject);

        var validationResult = new List<ValidationResult>();
        var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
        Assert.IsFalse(actual);
        Assert.AreEqual(2, validationResult.Count);
        Assert.IsTrue(validationResult.All(r => r.ErrorMessage == "One of the group 'Group 2' is required"));
    }


    [TestMethod]
    public void IsValid_BothGroupWithoutValue_ReturnsFalse() {
        var mockObject = new MockObjectWithOneInGroupRequiredValidation();
        var validationContext = new ValidationContext(mockObject);

        var validationResult = new List<ValidationResult>();
        var actual = Validator.TryValidateObject(mockObject, validationContext, validationResult, true);
        Assert.IsFalse(actual);
        Assert.AreEqual(4, validationResult.Count);
    }

    #endregion

    #region IsValid

    [TestMethod]
    public void IsValid_ValueHasAValue_ReturnsTrue() {
        var model = new MockObjectWithOneInGroupRequiredValidation { Property1 = "1" };
        this.Target = new OneInGroupRequiredAttribute("Group 1");
        var actual = this.Target.IsValid(model, model.Property1);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void IsValid_OtherGroupMemberHasValue_ReturnsTrue() {
        var model = new MockObjectWithOneInGroupRequiredValidation { Property2 = "2" };
        this.Target = new OneInGroupRequiredAttribute("Group 1");
        var actual = this.Target.IsValid(model, model.Property1);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void IsValid_EmptyStringValues_ReturnsFalse() {
        var model = new MockObjectWithOneInGroupRequiredValidation { Property1 = "", Property2 = "", Property3 = "", Property4 = "" };
        this.Target = new OneInGroupRequiredAttribute("Group 1");
        var actual = this.Target.IsValid(model, model.Property1);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void IsValid_OnlyOtherGroupHasValues_ReturnsFalse() {
        var model = new MockObjectWithOneInGroupRequiredValidation { Property3 = "3", Property4 = "4" };
        this.Target = new OneInGroupRequiredAttribute("Group 1");
        var actual = this.Target.IsValid(model, model.Property1);
        Assert.IsFalse(actual);
    }

    #endregion
}