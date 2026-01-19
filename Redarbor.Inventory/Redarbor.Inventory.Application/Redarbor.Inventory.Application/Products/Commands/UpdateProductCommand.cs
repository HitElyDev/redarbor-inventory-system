using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Products.Commands;
public class UpdateProductCommand : IRequest<Unit>
{
    public Product Product { get; set; } = new();
}