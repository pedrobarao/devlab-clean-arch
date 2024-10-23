using System.ComponentModel.DataAnnotations;
using Lab.Core.Commons.ValueObjects;

namespace Lab.WebApi.Core.ModelStateValidations;

public class CpfValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not string cpf) throw new ArgumentException("CPF shloud be a string.");

        if (!Cpf.Validate(cpf)) return new ValidationResult("Invalid CPF.");

        return ValidationResult.Success!;
    }
}