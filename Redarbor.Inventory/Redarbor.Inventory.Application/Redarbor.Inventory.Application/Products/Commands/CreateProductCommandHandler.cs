using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Application.Products.Commands;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;
    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productId = await _repository.AddAsync(request.Product);

        return productId;
    }
}