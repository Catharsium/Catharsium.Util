using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Catharsium.Util.Validation
{
    public class GroupRequiredAttribute : ValidationAttribute
    {
        private string GroupName { get; }


        public GroupRequiredAttribute(string groupName)
        {
            this.GroupName = groupName;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = this.IsValid(validationContext.ObjectInstance, validationContext.MemberName);
            if (isValid) {
                return ValidationResult.Success;
            }

            var message = new StringBuilder();
            message.Append(validationContext.MemberName);
            return new ValidationResult($"One of {message} is required");
        }


        public bool IsValid(object model, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) {
                return true;
            }

            var groupMembersAreEmpty = new List<bool>();
            var type = model.GetType();
            foreach (var property in type.GetProperties()) {
                var attributes = property.GetCustomAttributes(typeof(GroupRequiredAttribute), false)
                    .OfType<GroupRequiredAttribute>()
                    .Where(a => a.GroupName == this.GroupName);
                if (attributes.Any()) {
                    var propertyValue = property.GetValue(model);
                    groupMembersAreEmpty.Add(propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString()));
                }
            }

            return groupMembersAreEmpty.Any(m => !m);
        }
    }
}