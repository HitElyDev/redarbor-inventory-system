using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Interfaces;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Products.Queries;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _repository;
    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return products;
    }
}