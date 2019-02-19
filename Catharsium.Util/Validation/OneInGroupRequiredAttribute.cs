using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Catharsium.Util.Validation
{
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
                : new ValidationResult($"Een van de groep {this.GroupName} is verplicht");
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
}