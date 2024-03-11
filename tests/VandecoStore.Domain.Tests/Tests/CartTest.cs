using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests
{
    [Collection(nameof(DomainCollection))]
    public class CartTest
    {
        private readonly DomainTestFixture _fixture;

        public CartTest(DomainTestFixture fixture) {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(8)]
        public void Cart_AddCartItem_CartItemShoulbBeAdded(int quantity)
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = new Mock<Product>().Object;

            //Act
            cart.AddCartItem(product, quantity);

            //Assert
            Assert.Single(cart.CartItems);
            Assert.Equal(quantity, cart.CartItems.First().Quantity);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(8)]
        public void Cart_AddCartItem_CartItemQuantityShouldBeIncrease(int quantity)
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = _fixture.GenerateValidProduct(quantity,10);
            cart.AddCartItem(product, quantity);

            //Act
            cart.AddCartItem(product, quantity);

            //Assert
            Assert.Single(cart.CartItems);
            Assert.Equal(quantity * 2, cart.CartItems.First().Quantity);
        }

        [Fact]
        public void Cart_RemoveCartItem_CartItemQuantityShouldBeDecreased()
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = _fixture.GenerateValidProduct(1,10);
            cart.AddCartItem(product, 3);

            //Act
            cart.RemoveCartItem(product, 1);

            //Assert
            Assert.Equal(2, cart.CartItems[0].Quantity);
        }

        [Fact]
        public void Cart_RemoveCartItem_CartItemShouldBeDeleted()
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = _fixture.GenerateValidProduct(1,10);
            cart.AddCartItem(product, 3);

            //Act
            cart.RemoveCartItem(product, 3);

            //Assert
            Assert.Empty(cart.CartItems);
        }
    }
}
