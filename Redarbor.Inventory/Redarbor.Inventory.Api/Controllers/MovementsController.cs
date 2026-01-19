using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Inventory.Application.Movements.Commands;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MovementsController : ControllerBase
{
    private readonly IMediator _mediator;
    public MovementsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(InventoryMovement movement)
    {
        var id = await _mediator.Send(new CreateMovementCommand { Movement = movement });

        return Ok(id);
    }
}
