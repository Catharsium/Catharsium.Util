using System.ComponentModel.DataAnnotations;
namespace Catharsium.Util.Web.Validation;

public class BsnAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var isValid = false;
        if (int.TryParse(value as string, out var bsnNumber)) {
            isValid = IsValid(bsnNumber);
        }

        return isValid
            ? ValidationResult.Success
            : new ValidationResult($"'{value}' is geen geldig BSN");
    }


    public static bool IsValid(int bsnNumber)
    {
        if (bsnNumber is <= 9999999 or > 999999999) {
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