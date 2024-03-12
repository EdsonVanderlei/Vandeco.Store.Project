using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    [Collection(nameof(DomainCollection))]
    public class OrderTest
    {
        private readonly DomainTestFixture _fixture;

        public OrderTest(DomainTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Trait("Entity", "Order")]
        [Fact]
        public void Order_AddProductOrder_ProductShouldBeAddedAndTotalPriceUpdated()
        {
            //Arrange
            var order = new Mock<Order>().Object;
            var productOrder = _fixture.GenerateValidProductOrder(10, 10);

            //Act
            order.AddProductOrder(productOrder);

            //Assert
            Assert.Single(order.ProductOrders);
            Assert.Equal(100, order.TotalPrice);
        }

        [Trait("Entity", "Order")]
        [Fact]
        public void Order_RemoveProductOrder_ProductShouldBeRemovedAndTotalPriceUpdated()
        {
            //Arrange
            var order = new Mock<Order>().Object;
            var productOrder = _fixture.GenerateValidProductOrder(10, 10);
            order.AddProductOrder(productOrder);

            //Act
            order.RemoveProductOrder(productOrder);

            //Assert
            Assert.Empty(order.ProductOrders);
            Assert.Equal(0, order.TotalPrice);
        }

        [Trait("Entity", "Order")]
        [Fact]
        public void Order_ChangeAddress_AddressShouldBeUpdate()
        {
            //Arrange
            var order = new Mock<Order>().Object;
            var address = _fixture.GenerateValidAddress();

            //Act
            order.ChangeAddress(address[0]);

            //Assert
            Assert.Equal(address[0], order.Address);
        }
    }
}
