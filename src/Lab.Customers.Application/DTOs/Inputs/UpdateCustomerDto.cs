using System.ComponentModel.DataAnnotations;

namespace Lab.Customers.Application.DTOs.Inputs;

public class UpdateCustomerDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public Guid Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Cpf { get; set; }
    public DateTime? BirthDate { get; set; }
}