using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    [Collection(nameof(DomainCollection))]
    public class StockServiceTest
    {
        private readonly DomainTestFixture _domainTestFixture;

        public StockServiceTest(DomainTestFixture domainTestFixture)
        {
            _domainTestFixture = domainTestFixture;
        }

        [Fact]
        public async Task StockService_DebitStock_ThrowsException()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var stockService = new StockService
            {
                _productRepository = productRepository.Object
            };

            //Act && Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => stockService.DebitStock(Guid.NewGuid(), 1));
            Assert.Equal("Product Not Found !", ex.Message);
        }

        [Fact]
        public async Task StockService_DebitStock_StockShouldBeDebited()
        {
            //Arrange
            var product = _domainTestFixture.GenerateValidProduct(2, 100.0m);
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: product);
            var stockService = new StockService
            {
                _productRepository = productRepository.Object
            };

            //Act
            await stockService.DebitStock(product.Id, 1);

            //Assert
            Assert.Equal(1, product.Quantity);
            productRepository.Verify(p => p.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task StockService_CreditStock_ThrowsException()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var stockService = new StockService
            {
                _productRepository = productRepository.Object
            };

            //Act && Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => stockService.CreditStock(Guid.NewGuid(), 1));
            Assert.Equal("Product Not Found !", ex.Message);
        }

        [Fact]
        public async Task StockService_CreditStock_StockShouldBeCredited()
        {
            //Arrange
            var product = _domainTestFixture.GenerateValidProduct(2, 100.0m);
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: product);
            var stockService = new StockService
            {
                _productRepository = productRepository.Object
            };

            //Act
            await stockService.CreditStock(product.Id, 1);

            //Assert
            Assert.Equal(3, product.Quantity);
            productRepository.Verify(p => p.Update(It.IsAny<Product>()), Times.Once);
        }
    }
}
