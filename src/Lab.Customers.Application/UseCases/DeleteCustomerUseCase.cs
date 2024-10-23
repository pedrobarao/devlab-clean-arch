using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class DeleteCustomerUseCase(ICustomerRepository customerRepository)
    : IDeleteCustomerUseCase, IUseCase<Guid, Result>
{
    public async Task<Result> Handle(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        if (customer is null)
        {
            Result.AddError("Customer not found.");
            return Result;
        }

        customerRepository.Delete(customer);
        await customerRepository.UnitOfWork.Commit();

        return Result;
    }

    public Result Result { get; } = new();

    public bool ValidateInput(Guid request)
    {
        throw new NotImplementedException();
    }
}