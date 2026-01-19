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
public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbConnectionFactory _dbFactory;
    public ProductRepository(ApplicationDbContext context, DbConnectionFactory dbFactory)
    {
        _context = context;
        _dbFactory = dbFactory;
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<int> AddAsync(Product product)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "INSERT INTO Products (CategoryId, Name, Sku, Price, Stock) VALUES (@CategoryId, @Name, @Sku, @Price, @Stock); SELECT CAST(SCOPE_IDENTITY() as int);";

        return await connection.QuerySingleAsync<int>(sql, product);
    }
    public async Task UpdateAsync(Product product)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "UPDATE Products SET CategoryId = @CategoryId, Name = @Name, Sku = @Sku, Price = @Price, Stock = @Stock WHERE Id = @Id";
        await connection.ExecuteAsync(sql, product);
    }
    public async Task DeleteAsync(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "DELETE FROM Products WHERE Id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}