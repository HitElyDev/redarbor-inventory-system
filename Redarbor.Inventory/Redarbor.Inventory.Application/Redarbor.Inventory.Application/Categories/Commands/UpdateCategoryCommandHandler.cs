using MediatR;
using Redarbor.Inventory.Application.Categories.Commands;
using Redarbor.Inventory.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Redarbor.Inventory.Application.Products.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;
    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Category);

        return Unit.Value;
    }
}

