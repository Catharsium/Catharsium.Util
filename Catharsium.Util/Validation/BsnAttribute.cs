using System.ComponentModel.DataAnnotations;

namespace Catharsium.Util.Validation
{
    public class BsnAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = false;
            if (int.TryParse(value as string, out var bsnNumber)) {
                isValid = this.IsValid(bsnNumber);
            }

            return isValid
                ? ValidationResult.Success
                : new ValidationResult($"'{value}' is geen geldig BSN");
        }


        public bool IsValid(int bsnNumber)
        {
            if (bsnNumber <= 9999999 || bsnNumber > 999999999) {
                return false;
            }

            var sum = -1 * bsnNumber % 10;

            for (var multiplier = 2; bsnNumber > 0; multiplier++) {
                var value = (bsnNumber /= 10) % 10;
                sum += multiplier * value;
            }

            return sum != 0 && sum % 11 == 0;
        }
    }
}