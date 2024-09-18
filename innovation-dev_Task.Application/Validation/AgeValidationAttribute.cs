using System.ComponentModel.DataAnnotations;

public class AgeValidationAttribute : ValidationAttribute
{
    private const int MinimumAge = 15;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age)) age--;
            if (age <= MinimumAge)
            {
                return new ValidationResult($"Student must be older than {MinimumAge} years.");
            } 
        }
        return ValidationResult.Success;
    }
}
