using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Redarbor.Inventory.Application.Movements.Commands;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Tests.Application.Movements
{
    public class MovementTests
    {
        private readonly Mock<IMovementRepository> _movementRepoMock;
        private readonly Mock<IProductRepository> _productRepoMock;
        public MovementTests()
        {
            _movementRepoMock = new Mock<IMovementRepository>();
            _productRepoMock = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_ShouldUpdateStock_WhenMovementIsCreated()
        {            
            var productId = 1;
            var initialProduct = new Redarbor.Inventory.Domain.Entities.Product
            {
                Id = productId,
                Stock = 10,
                Name = "Test Product"
            };
            _productRepoMock.Setup(r => r.GetByIdAsync(productId))
                .ReturnsAsync(initialProduct);
            _movementRepoMock.Setup(r => r.AddMovementAsync(It.IsAny<InventoryMovement>()))
                .ReturnsAsync(1);
            var handler = new CreateMovementCommandHandler(_movementRepoMock.Object, _productRepoMock.Object);            
            var command = new CreateMovementCommand();   
            await handler.Handle(command, CancellationToken.None);            
            _productRepoMock.Verify(r => r.UpdateAsync(It.IsAny<Redarbor.Inventory.Domain.Entities.Product>()), Times.Once);
        }
    }
}