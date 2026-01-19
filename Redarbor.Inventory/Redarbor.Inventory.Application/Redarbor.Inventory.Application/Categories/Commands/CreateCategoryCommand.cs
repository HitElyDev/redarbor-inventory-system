using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Redarbor.Inventory.Domain.Entities;
namespace Redarbor.Inventory.Application.Categories.Commands;
public class CreateCategoryCommand : IRequest<int>
{
    public Category Category { get; set; } = new();
}