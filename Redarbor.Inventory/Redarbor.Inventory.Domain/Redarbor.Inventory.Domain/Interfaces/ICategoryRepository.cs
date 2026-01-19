using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Domain.Interfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<int> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}