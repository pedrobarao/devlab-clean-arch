using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerLegalAgeSpec : Specification<Customer>
{
    public override bool IsSatisfiedBy(Customer entity)
    {
        return entity.BirthDate.ToDateTime(TimeOnly.MinValue) <= DateTime.Now.AddYears(-18);
    }
}