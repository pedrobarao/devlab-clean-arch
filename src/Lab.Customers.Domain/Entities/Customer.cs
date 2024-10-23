using Lab.Core.Commons.Entities;
using Lab.Core.Commons.Specifications;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.Specifications.Validators;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Customers.Domain.Entities;

public class Customer : Entity, IAggregateRoot
{
    protected Customer()
    {
    }

    public Customer(Name name, Cpf cpf, DateOnly birthDate)
    {
        Name = name;
        Cpf = cpf;
        BirthDate = birthDate;
    }

    public Name Name { get; private set; } = null!;
    public Cpf Cpf { get; private set; } = null!;
    public DateOnly BirthDate { get; private set; }

    public ValidationResult Validate()
    {
        return new CustomerValidator().Validate(this);
    }

    public void UpdateName(Name name)
    {
        throw new NotImplementedException();
    }
}