using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface IGetCustomerUseCase
{
    Task<Result<CustomerDto?>> Handle(Guid id);
}