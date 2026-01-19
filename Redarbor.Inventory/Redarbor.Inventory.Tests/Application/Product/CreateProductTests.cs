using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Redarbor.Inventory.Application.Products.Commands;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Tests.Application
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        public CreateProductCommandHandlerTests()
        {
            _repositoryMock = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_ShouldCreateProduct_WhenDataIsValid()
        {            
            var command = new CreateProductCommand();           
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Redarbor.Inventory.Domain.Entities.Product>())).ReturnsAsync(1);
            var handler = new CreateProductCommandHandler(_repositoryMock.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.True(result > 0);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Redarbor.Inventory.Domain.Entities.Product>()), Times.Once);
        }
    }
}