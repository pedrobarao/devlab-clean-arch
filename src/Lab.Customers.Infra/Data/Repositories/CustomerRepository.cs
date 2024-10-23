using Dapper;
using Lab.Core.Commons.Communication;
using Lab.Core.Commons.Data;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.Entities;
using Lab.Customers.Domain.Repositories;
using Lab.Customers.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lab.Customers.Infra.Data.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context!;

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<PagedResult<Customer>> ListPagedAsync(int pageSize, int pageIndex, string? query = null)
    {
        const string sql = @"SELECT ""Id"",
                                    ""BirthDate"",
                                    ""FirstName"",
                                    ""LastName"",
                                    ""Cpf"" AS ""Number""
                       FROM ""Customers"" 
                      WHERE (@query IS NULL OR UPPER(""FirstName"") LIKE '%' || @query || '%')
                         OR (@query IS NULL OR UPPER(""LastName"") LIKE '%' || @query || '%')
                      ORDER BY ""FirstName""
                      LIMIT @pageSize OFFSET @pageIndex * @pageSize";

        const string count = @"SELECT COUNT(""Id"") 
                                 FROM ""Customers"" 
                                WHERE (@query IS NULL OR UPPER(""FirstName"") LIKE '%' || @query || '%')
                                   OR (@query IS NULL OR UPPER(""LastName"") LIKE '%' || @query || '%')";

        var queryParams = new { pageSize, pageIndex, query = query?.ToUpper() };

        var customers = await _context.Database.GetDbConnection()
            .QueryAsync<Customer, Name, Cpf, Customer>(sql,
                (customer, name, cpf) => new Customer(customer.Id, name, cpf, customer.BirthDate), queryParams,
                splitOn: "Id,FirstName,Number");

        var totalItems = await _context.Database.GetDbConnection()
            .QueryFirstOrDefaultAsync<int>(count, queryParams);

        return new PagedResult<Customer>(customers, totalItems, pageIndex, pageSize, query);
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}