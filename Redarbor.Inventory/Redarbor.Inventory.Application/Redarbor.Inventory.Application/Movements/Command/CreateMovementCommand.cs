using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Movements.Commands;
public class CreateMovementCommand : IRequest<int>
{
    public InventoryMovement Movement { get; set; } = new();
}