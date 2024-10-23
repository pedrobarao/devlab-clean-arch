namespace Lab.Customers.Application.DTOs.Inputs;

public class QueryCustomerDto
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public string? Filter { get; set; }
}