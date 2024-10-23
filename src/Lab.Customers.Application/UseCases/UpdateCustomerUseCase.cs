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

public class UpdateCustomerUseCase(ICustomerRepository customerRepository) : IUpdateCustomerUseCase, IUseCase<UpdateCustomerDto, Result>
{
    public async Task<Result> Handle(UpdateCustomerDto updateCustomer)
    {
        var customer = await customerRepository.GetByIdAsync(updateCustomer.Id);
        
        if (customer is null)
        {
            Result.AddError("Customer not found.");
            return Result;
        }
        
        customer.UpdateName(new Name(updateCustomer.FirstName, updateCustomer.LastName));
        customer.UpdateCpf(new Cpf(updateCustomer.Cpf));
        customer.UpdateBirthDate(updateCustomer.BirthDate);
        
        var validationResult = customer.Validate();

        if (!validationResult.IsValid)
        {
            Result.AddErrors(validationResult);
            return Result;
        }

        customerRepository.Update(customer);
        await customerRepository.UnitOfWork.Commit();

        return Result;
    }

    public Result Result { get; } = new();
}