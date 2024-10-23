using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Entities;
using Lab.Customers.Domain.Repositories;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Customers.Application.UseCases;

public class CreateCustomerUseCase(ICustomerRepository customerRepository)
    : ICreateCustomerUseCase, IUseCase<NewCustomerDto, Result<CustomerCreatedDto>>
{
    public async Task<Result<CustomerCreatedDto>> Handle(NewCustomerDto newCustomerDto)
    {
        var name = new Name(newCustomerDto.FirstName, newCustomerDto.LastName);
        var cpf = new Cpf(newCustomerDto.Cpf);
        var customer = new Customer(name, cpf, newCustomerDto.BirthDate);
        var validationResult = customer.Validate();

        if (!validationResult.IsValid) Result.AddErrors(validationResult);

        customerRepository.Add(customer);
        await customerRepository.UnitOfWork.Commit();

        Result.SetData(new CustomerCreatedDto { Id = customer.Id });

        return Result;
    }

    public Result<CustomerCreatedDto> Result { get; } = new();

    public bool ValidateInput(NewCustomerDto request)
    {
        throw new NotImplementedException();
    }
}