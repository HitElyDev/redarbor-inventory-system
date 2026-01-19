using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Domain.Interfaces;

public interface IMovementRepository
{
    Task<int> AddMovementAsync(InventoryMovement movement);
    Task<IEnumerable<InventoryMovement>> GetAllAsync();
}
