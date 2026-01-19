using Dapper;
using Microsoft.EntityFrameworkCore;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
using Redarbor.Inventory.Infrastructure.Data;
using Redarbor.Inventory.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Redarbor.Inventory.Infrastructure.Repositories;
public class MovementRepository : IMovementRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbConnectionFactory _dbFactory;
    public MovementRepository(ApplicationDbContext context, DbConnectionFactory dbFactory)
    {
        _context = context;
        _dbFactory = dbFactory;
    }
    public async Task<int> AddMovementAsync(InventoryMovement movement)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "INSERT INTO InventoryMovements (ProductId, Quantity, Type, MovementDate) VALUES (@ProductId, @Quantity, @Type, @MovementDate); SELECT CAST(SCOPE_IDENTITY() as int);";
        
        return await connection.QuerySingleAsync<int>(sql, movement);
    }
    public async Task<IEnumerable<InventoryMovement>> GetAllAsync()
    {
        return await _context.InventoryMovements.AsNoTracking().ToListAsync();
    }


}