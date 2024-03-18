using Moq;

using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    public class CartServiceTest
    {
        [Fact]
        public async Task CartService_UpdateCartItems_ThrowException()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var cartService = new CartService
            {
                _productRepository = productRepository.Object,
                _userRepository = userRepository.Object,
            };

            //Act && Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => cartService.UpdateCartItems([], Guid.NewGuid()));
            Assert.Equal("User Not Found !", ex.Message);
        }
    }
}
