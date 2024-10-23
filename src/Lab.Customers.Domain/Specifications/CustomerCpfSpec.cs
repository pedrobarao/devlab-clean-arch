using Lab.Core.Commons.Specifications;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerCpfSpec : Specification<Customer>
{
    public override bool IsSatisfiedBy(Customer entity)
    {
        return Cpf.Validate(entity.Cpf.Number);
    }
}