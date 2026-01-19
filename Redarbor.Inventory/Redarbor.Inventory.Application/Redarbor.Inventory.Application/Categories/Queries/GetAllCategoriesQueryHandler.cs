using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Categories.Queries;
public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _repository;
    public GetAllCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();

        return categories;
    }
}