using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Application.Movements.Commands;
public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, int>
{
    private readonly IMovementRepository _movementRepository;
    private readonly IProductRepository _productRepository;
    public CreateMovementCommandHandler(IMovementRepository movementRepository, IProductRepository productRepository)
    {
        _movementRepository = movementRepository;
        _productRepository = productRepository;
    }
    public async Task<int> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Movement.ProductId);
        if (product == null) return 0;
        if (request.Movement.Type.ToLower() == "entry") product.Stock += request.Movement.Quantity;
        else product.Stock -= request.Movement.Quantity;
        await _productRepository.UpdateAsync(product);

        return await _movementRepository.AddMovementAsync(request.Movement);
    }
}