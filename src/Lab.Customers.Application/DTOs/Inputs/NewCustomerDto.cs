using System.ComponentModel.DataAnnotations;

namespace Lab.Customers.Application.DTOs.Inputs;

public class NewCustomerDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public required string Cpf { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public DateOnly BirthDate { get; set; }
}