using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications.Validators;

public class CustomerValidator : SpecificationValidator<Customer>
{
    public CustomerValidator()
    {
        Add("legalAge", new Rule<Customer>(new CustomerLegalAgeSpec(), "Invalid customer age."));
        Add("cpf", new Rule<Customer>(new CustomerCpfSpec(), "Invalid customer CPF."));
        Add("fullName", new Rule<Customer>(new CustomerFullNameSpec(), "Invalid customer name."));
    }
}