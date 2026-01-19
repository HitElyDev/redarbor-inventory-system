using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Inventory.Application.Products.Commands;
using Redarbor.Inventory.Application.Products.Queries;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(Product product)
    {
        var id = await _mediator.Send(new CreateProductCommand { Product = product });

        return Ok(id);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest();
        await _mediator.Send(new UpdateProductCommand { Product = product });

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand { Id = id });

        return NoContent();
    }
}