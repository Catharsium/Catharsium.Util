using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Catharsium.Util.Web.Validation;

public class RequiredWithAttribute(params string[] properties) : ValidationAttribute
{
    private string[] Properties { get; } = properties;


    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        var isValid = this.IsValid(value?.ToString(), validationContext.ObjectInstance);
        if(isValid) {
            return ValidationResult.Success;
        }

        var message = new StringBuilder();
        message.Append(validationContext.MemberName);
        foreach(var property in this.Properties) {
            message.Append($", {property}");
        }

        return new ValidationResult($"{message} are all required");
    }


    public bool IsValid(string value, object model) {
        var type = model.GetType();
        var propertyIsFilled = this.Properties.Select(p => type.GetProperty(p).GetValue(model, null)).Select(v => !string.IsNullOrWhiteSpace(v?.ToString())).ToList();
        return string.IsNullOrWhiteSpace(value) || propertyIsFilled.All(p => p);
    }
}