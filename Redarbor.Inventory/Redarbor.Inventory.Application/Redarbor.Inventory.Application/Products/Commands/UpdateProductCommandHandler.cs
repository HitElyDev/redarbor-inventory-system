using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Application.Products.Commands;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repository;
    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Product);

        return Unit.Value;
    }
}
