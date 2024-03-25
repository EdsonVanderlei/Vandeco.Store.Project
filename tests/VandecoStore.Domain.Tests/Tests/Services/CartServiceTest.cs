using Moq;
using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    public class CartServiceTest
    {
        [Fact]
        public async Task CartService_UpdateCartItems_ThrowExceptionUserNotFound()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value: null);
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

        [Fact]
        public async Task CartService_UpdateCartItems_ThrowExceptionProductNotFound()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var cartItemDTO = new CartItemDTO
            {
                ItemId = guid,
                Quantiy = 3,
            };
            var productRepository = new Mock<IProductRepository>();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<User>().Object);
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var cartService = new CartService
            {
                _productRepository = productRepository.Object,
                _userRepository = userRepository.Object,
            };

            //Act && Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => cartService.UpdateCartItems([cartItemDTO], Guid.NewGuid()));
            Assert.Equal($"Item {guid} Not Found !", ex.Message);
        }

        [Fact]
        public async Task CartService_UpdateCartItems_CartShouldBeUpdated()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>().Object;
            var cartItemDTO = new CartItemDTO
            {
                ItemId = guid,
                Quantiy = 3,
            };
            var productRepository = new Mock<IProductRepository>();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value: user);
            productRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<Product>().Object);
            var cartService = new CartService
            {
                _productRepository = productRepository.Object,
                _userRepository = userRepository.Object,
            };

            //Act
            await cartService.UpdateCartItems([cartItemDTO], Guid.NewGuid());

            //Assert 
            Assert.Single(user.Cart.CartItems);
            Assert.Equal(3, user.Cart.CartItems.First().Quantity);
            userRepository.Verify(p => p.SaveChanges(),Times.Once);
        }

        [Fact]
        public async Task CartService_ClearCart_ThrowsException()
        {
            //Arrange 
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value: null);
            var cartService = new CartService
            {
                _productRepository = new Mock<IProductRepository>().Object,
                _userRepository = userRepository.Object,    
            };

            //Act && Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => cartService.ClearCart(Guid.NewGuid()));
            Assert.Equal("User Not Found !", ex.Message);
        }

        [Fact]
        public async Task CartService_ClearCart_CartShouldBeClean()
        {
            //Arrange 
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value: new Mock<User>().Object);
            var cartService = new CartService
            {
                _productRepository = new Mock<IProductRepository>().Object,
                _userRepository = userRepository.Object,
            };

            //Act 
            await cartService.ClearCart(Guid.NewGuid());

            //Assert
            userRepository.Verify(p => p.SaveChanges(),Times.Once);
        }

        [Fact]
        public async Task CartService_GetCartItemsFromUser()
        {
            //Arrange 
            var user = new Mock<User>().Object;
            user.Cart.UpdateCartItems(new Mock<Product>().Object,2);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetUserWithCart(It.IsAny<Guid>())).ReturnsAsync(value:  user);
            var cartService = new CartService
            {
                _productRepository = new Mock<IProductRepository>().Object,
                _userRepository = userRepository.Object,
            };

            //Act
            var items = await cartService.GetCartItemsFromUser(Guid.NewGuid());

            //Assert
            Assert.Single(items);

        }
    }
}
