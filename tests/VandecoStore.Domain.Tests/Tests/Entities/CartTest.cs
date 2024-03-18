using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    [Collection(nameof(DomainCollection))]
    public class CartTest
    {
        private readonly DomainTestFixture _fixture;

        public CartTest(DomainTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Trait("Entity", "Cart")]
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(8)]
        public void Cart_UpdateCartItem_CartItemShoulbBeUpdate(int quantity)
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = new Mock<Product>().Object;

            //Act
            cart.UpdateCartItems(product, quantity);

            //Assert
            Assert.Single(cart.CartItems);
            Assert.Equal(quantity, cart.CartItems.First().Quantity);
        }

        [Fact]
        public void Cart_UpdateCartItem_CartItemShoulbBeDeleted()
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = _fixture.GenerateValidProduct(3, 10.0m);
            cart.UpdateCartItems(product, 3);

            //Act
            cart.UpdateCartItems(product, 0);

            //Assert
            Assert.Empty(cart.CartItems);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-13)]
        [InlineData(-20)]
        [InlineData(-10)]
        public void Cart_UpdateCartItem_ThrowsException(int quantity)
        {
            //Arrange
            var cart = new Mock<Cart>().Object;
            var product = _fixture.GenerateValidProduct(3, 10.0m);
            cart.UpdateCartItems(product, 3);

            //Act
            var ex = Assert.Throws<DomainException>(() => cart.UpdateCartItems(product, quantity));

            //Assert
            Assert.Equal("The Field Must Be Greather Than 0 !", ex.Message);
        }
    }
}
