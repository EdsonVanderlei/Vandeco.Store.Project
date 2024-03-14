using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
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

        [Fact]
        public void Order_UpdateStatusOrder_StatusShouldBeUpdated()
        {
            //Arrange
            var order = new Mock<Order>().Object;

            //Act
            order.UpdateOrderStatus("Edson", StatusProcessEnum.Preparing);

            //Assert
            Assert.Equal("Edson", order.OrdersStatus[0].Notifier); ;
            Assert.Equal(StatusProcessEnum.Preparing, order.OrdersStatus[0].StatusProcessEnum);
        }
    }
}
