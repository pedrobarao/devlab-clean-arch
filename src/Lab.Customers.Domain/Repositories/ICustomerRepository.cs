using Lab.Core.Commons.Communication;
using Lab.Core.Commons.Data;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    void Add(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);
    Task<PagedResult<Customer>> ListPagedAsync(int pageSize, int pageIndex, string? query = null);
    void Update(Customer customer);
    void Delete(Customer customer);
}