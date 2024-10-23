using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class GetCustomerUseCase(ICustomerRepository customerRepository)
    : IGetCustomerUseCase, IUseCase<Guid, Result<CustomerDto?>>
{
    public async Task<Result<CustomerDto?>> Handle(Guid id)
    {
        var customers = await customerRepository.GetByIdAsync(id);

        if (customers is null) return Result;

        Result.SetData(new CustomerDto
        {
            Id = customers.Id,
            FirstName = customers.Name.ToString(),
            Cpf = customers.Cpf.ToString(),
            BirthDate = customers.BirthDate
        });

        return Result;
    }

    public Result<CustomerDto?> Result { get; } = new();
}