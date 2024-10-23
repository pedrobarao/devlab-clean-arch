using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface ICreateCustomerUseCase
{
    Task<Result<CustomerCreatedDto>> Handle(NewCustomerDto newCustomerDto);
}