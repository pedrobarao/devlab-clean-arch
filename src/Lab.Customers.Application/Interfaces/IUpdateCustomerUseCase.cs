using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;

namespace Lab.Customers.Application.Interfaces;

public interface IUpdateCustomerUseCase
{
    Task<Result> Handle(UpdateCustomerDto updateCustomer);
}