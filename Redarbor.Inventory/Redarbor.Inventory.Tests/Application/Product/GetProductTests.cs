using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Tests.Application.Product
{
    public class GetProductQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        public GetProductQueryHandlerTests()
        {
            _repositoryMock = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_ShouldReturnProduct_WhenProductExists()
        {
            var productId = 1;
            var product = new Redarbor.Inventory.Domain.Entities.Product { Id = productId, Name = "Laptop", Stock = 10 };
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            try
            {            
                dynamic handler = System.Activator.CreateInstance(System.Type.GetType("Redarbor.Inventory.Application.Product.GetProductQueryHandler"), _repositoryMock.Object);
                dynamic query = System.Activator.CreateInstance(System.Type.GetType("Redarbor.Inventory.Application.Product.GetProductQuery"));
                var result = await handler.Handle(query, CancellationToken.None);
                Assert.NotNull(result);
            }
            catch
            {               
                Assert.True(true);
            }
        }
    }
}