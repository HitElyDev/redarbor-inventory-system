using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Application.Categories.Commands;
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _repository;
    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryId = await _repository.AddAsync(request.Category);

        return categoryId;
    }
}