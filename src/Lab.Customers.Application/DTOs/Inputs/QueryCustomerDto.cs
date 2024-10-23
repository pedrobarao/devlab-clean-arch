namespace Lab.Customers.Application.DTOs.Inputs;

public class QueryCustomerDto
{
    public int PageSize { get; set; } = 10;
    public int PageIndex { get; set; } = 1;
    public string? Filter { get; set; }
}