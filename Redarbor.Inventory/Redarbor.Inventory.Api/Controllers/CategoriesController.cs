using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Inventory.Application.Categories.Commands;
using Redarbor.Inventory.Application.Categories.Queries;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());

        return Ok(categories);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(Category category)
    {
        var id = await _mediator.Send(new CreateCategoryCommand { Category = category });

        return Ok(id);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Category category)
    {
        if (id != category.Id) return BadRequest();
        await _mediator.Send(new UpdateCategoryCommand { Category = category });

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand { Id = id });

        return NoContent();
    }
}