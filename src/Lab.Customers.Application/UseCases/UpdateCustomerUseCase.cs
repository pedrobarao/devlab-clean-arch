using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class UpdateCustomerUseCase : IUpdateCustomerUseCase, IUseCase<UpdateCustomerDto, Result>
{
    public async Task<Result> Handle(UpdateCustomerDto updateCustomer)
    {
        return Result;
    }

    public Result Result { get; } = new();

    public bool ValidateInput(UpdateCustomerDto request)
    {
        throw new NotImplementedException();
    }
}