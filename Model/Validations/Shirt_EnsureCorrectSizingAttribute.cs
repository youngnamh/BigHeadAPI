using System.ComponentModel.DataAnnotations;

namespace BigHeadAPI.Model.Validations;

public class Shirt_EnsureCorrectSizingAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var shirt = validationContext.ObjectInstance as Shirt;

        if (shirt != null)
        {
            if (shirt.Size > 8)
            {
                return new ValidationResult("The size has to be less than 8");
            }
        }
        return ValidationResult.Success;
    }
}