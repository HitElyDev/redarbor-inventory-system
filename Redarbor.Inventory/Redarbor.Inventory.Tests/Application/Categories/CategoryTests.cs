using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Redarbor.Inventory.Application.Categories.Commands;
using Redarbor.Inventory.Domain.Entities;
using Redarbor.Inventory.Domain.Interfaces;
namespace Redarbor.Inventory.Tests.Application.Categories
{
    public class CategoryTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepoMock;
        public CategoryTests()
        {
            _categoryRepoMock = new Mock<ICategoryRepository>();
        }
        [Fact]
        public async Task Handle_ShouldCreateCategory_WhenDataIsValid()
        {           
            var command = new CreateCategoryCommand();
            _categoryRepoMock.Setup(r => r.AddAsync(It.IsAny<Category>())).ReturnsAsync(1);
            var handler = new CreateCategoryCommandHandler(_categoryRepoMock.Object);            
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.True(result > 0);
            _categoryRepoMock.Verify(r => r.AddAsync(It.IsAny<Category>()), Times.Once);
        }
    }
}