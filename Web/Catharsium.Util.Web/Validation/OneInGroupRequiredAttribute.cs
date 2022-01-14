using System.ComponentModel.DataAnnotations;
namespace Catharsium.Util.Web.Validation;

public class OneInGroupRequiredAttribute : ValidationAttribute
{
    private string GroupName { get; }


    public OneInGroupRequiredAttribute(string groupName)
    {
        this.GroupName = groupName;
    }


    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var isValid = this.IsValid(validationContext.ObjectInstance, value as string);
        return isValid
            ? ValidationResult.Success
            : new ValidationResult($"One of the group '{this.GroupName}' is required");
    }


    public bool IsValid(object model, string value)
    {
        if (!string.IsNullOrWhiteSpace(value)) {
            return true;
        }

        var type = model.GetType();
        var groupMembersAreEmpty = (from property in type.GetProperties()
                                    let attributes = property.GetCustomAttributes(typeof(OneInGroupRequiredAttribute), false)
                                        .OfType<OneInGroupRequiredAttribute>()
                                        .Where(a => a.GroupName == this.GroupName)
                                    where attributes.Any()
                                    select property.GetValue(model)
            into propertyValue
                                    select propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString())).ToList();

        return groupMembersAreEmpty.Any(m => !m);
    }
}