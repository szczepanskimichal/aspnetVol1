using System.ComponentModel.DataAnnotations;

namespace aspnetVol1.Models.Validations;

public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
{
 protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
 {
    var shirt = validationContext.ObjectInstance as Shirt;
    if (shirt != null & !string.IsNullOrWhiteSpace(shirt.Gender))
    {
        if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
        {
            return new ValidationResult("Men's shirts must be size 8 or larger.");
        }
        else if(shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
        {
            return new ValidationResult("women's shirts must be size 6 or larger.");
        }
    }
    return ValidationResult.Success;
 }
}