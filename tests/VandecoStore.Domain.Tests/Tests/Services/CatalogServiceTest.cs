using Moq;
using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    [Collection(nameof(CatalogFixtureCollection))]
    public class CatalogServiceTest
    {
        readonly CatalogFixture _catalogFixture;

        public CatalogServiceTest(CatalogFixture catalogFixture)
        {
            _catalogFixture = catalogFixture;
        }

        [Fact]
        public async Task CatalogService_AddProductToCatalog_ThrowsException()
        {
            //Arrange
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var productRepository = new Mock<IProductRepository>();
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act && Assert 
            var ex = await Assert.ThrowsAsync<DomainException>(() => catalogService.AddProductToCatalog(new Mock<ProductRegisterDTO>().Object));
            Assert.Equal("Brand Not Found !", ex.Message);
        }

        [Fact]
        public async Task CatalogService_AddProductToCatalog_ProductShouldBeAdded()
        {
            //Arrange
            var productRegisterDTO = _catalogFixture.GenerateValidProductRegisterDTO();
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<Brand>().Object);
            var productRepository = new Mock<IProductRepository>();
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act
            await catalogService.AddProductToCatalog(productRegisterDTO);

            //Assert
            productRepository.Verify(p => p.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task CatalogService_DesactivateProduct_ThrowException()
        {
            //Arrange
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var productRepository = new Mock<IProductRepository>();
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act && Assert 
            var ex = await Assert.ThrowsAsync<DomainException>(() => catalogService.DesactivateProduct(Guid.NewGuid()));
            Assert.Equal("Product Not Found !", ex.Message);
        }

        [Fact]
        public async Task CatalogService_ActivateProduct_ThrowException()
        {
            //Arrange
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var productRepository = new Mock<IProductRepository>();
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act && Assert 
            var ex = await Assert.ThrowsAsync<DomainException>(() => catalogService.ActivateProduct(Guid.NewGuid()));
            Assert.Equal("Product Not Found !", ex.Message);
        }
        [Fact]
        public async Task CatalogService_DesactivateProduct_ProductShouldBeDesactivate()
        {
            //Arrange
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<Brand>().Object);
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(new Mock<Product>().Object);
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act
            await catalogService.DesactivateProduct(Guid.NewGuid());

            //Assert
            productRepository.Verify(p => p.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task CatalogService_ActivateProduct_ProductShouldBeActivate()
        {
            //Arrange
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<Brand>().Object);
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(new Mock<Product>().Object);
            var catalogService = new CatalogService
            {
                _brandRepository = brandRepository.Object,
                _productRepository = productRepository.Object,
            };

            //Act
            await catalogService.ActivateProduct(Guid.NewGuid());

            //Assert
            productRepository.Verify(p => p.Update(It.IsAny<Product>()), Times.Once);
        }
    }
}
