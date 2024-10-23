using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerFullNameSpec : Specification<Customer>
{
    public override bool IsSatisfiedBy(Customer entity)
    {
        return entity.Name.IsValid();
    }
}