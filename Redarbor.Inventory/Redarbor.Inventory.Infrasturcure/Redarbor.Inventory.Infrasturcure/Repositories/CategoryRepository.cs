using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
using Redarbor.Inventory.Infrastructure.Data;
using Redarbor.Inventory.Infrastructure.Persistence;
namespace Redarbor.Inventory.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbConnectionFactory _dbFactory;
    public CategoryRepository(ApplicationDbContext context, DbConnectionFactory dbFactory)
    {
        _context = context;
        _dbFactory = dbFactory;
    }
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }
    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<int> AddAsync(Category category)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int);";

        return await connection.QuerySingleAsync<int>(sql, category);
    }
    public async Task UpdateAsync(Category category)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
        await connection.ExecuteAsync(sql, category);
    }
    public async Task DeleteAsync(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        const string sql = "DELETE FROM Categories WHERE Id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}