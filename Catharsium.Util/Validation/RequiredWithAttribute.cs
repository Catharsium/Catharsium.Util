﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Catharsium.Util.Validation
{
    public class RequiredWithAttribute : ValidationAttribute
    {
        private string[] Properties { get; }


        public RequiredWithAttribute(params string[] properties)
        {
            this.Properties = properties;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = this.IsValid(value?.ToString(), validationContext.ObjectInstance);
            if (isValid) {
                return ValidationResult.Success;
            }

            var message = new StringBuilder();
            message.Append(validationContext.MemberName);
            foreach (var property in this.Properties) {
                message.Append($", {property}");
            }
            return new ValidationResult($"{message} are required together");
        }


        public bool IsValid(string value, object model)
        {
            var type = model.GetType();
            var propertyIsFilled = this.Properties.Select(p => type.GetProperty(p).GetValue(model, null))
                .Select(v => !string.IsNullOrWhiteSpace(v?.ToString())).ToList();
            return string.IsNullOrWhiteSpace(value) || propertyIsFilled.All(p => p);
        }
    }
}