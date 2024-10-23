using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;
using Lab.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Customers.Api.v1.Controllers;

[Route("api/v1/customers")]
public class CustomerController : MainController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices] ICreateCustomerUseCase createCustomerUseCase,
        NewCustomerDto newCustomer)
    {
        var result = await createCustomerUseCase.Handle(newCustomer);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return Created($"{result.Data!.Id}", result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromServices] IGetCustomerUseCase getCustomerUseCase, Guid id)
    {
        var result = await getCustomerUseCase.Handle(id);
        return result.Data is null ? NotFound() : Ok(result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> List([FromServices] IListCustomerUseCase listCustomerUseCase,
        int pageSize = 10,
        int pageIndex = 0,
        string? query = null)
    {
        var result = await listCustomerUseCase.Handle(new QueryCustomerDto
        {
            PageSize = pageSize,
            PageIndex = pageIndex,
            Filter = query
        });
        
        return Ok(result.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromServices] IUpdateCustomerUseCase updateCustomerUseCase,
        UpdateCustomerDto updateCustomer, [FromRoute] Guid id)
    {
        if (id != updateCustomer.Id) return BadRequest("The consumer id is not valid.");

        var result = await updateCustomerUseCase.Handle(updateCustomer);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromServices] IDeleteCustomerUseCase deleteCustomerUseCase, Guid id)
    {
        var result = await deleteCustomerUseCase.Handle(id);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return NoContent();
    }
}