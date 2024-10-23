namespace Lab.Customers.Application.DTOs.Outputs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string? Cpf { get; set; }
    public DateOnly BirthDate { get; set; }
}