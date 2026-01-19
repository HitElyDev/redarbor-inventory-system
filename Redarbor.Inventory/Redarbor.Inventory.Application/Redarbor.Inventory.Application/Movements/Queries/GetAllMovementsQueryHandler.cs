using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Movements.Queries;
public class GetAllMovementsQueryHandler : IRequestHandler<GetAllMovementsQuery, IEnumerable<InventoryMovement>>
{
    private readonly IMovementRepository _repository;
    public GetAllMovementsQueryHandler(IMovementRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<InventoryMovement>> Handle(GetAllMovementsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}