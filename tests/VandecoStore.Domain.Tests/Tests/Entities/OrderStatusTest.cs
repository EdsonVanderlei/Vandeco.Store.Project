using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class OrderStatusTest
    {
        [Fact]
        public void OrderStatus_Validate_ThrowsException()
        {
            //Arrange, Act && Assert
            var ex = Assert.Throws<DomainException>(() => new OrderStatus
            {
                Notifier = string.Empty,
                Order = new Mock<Order>().Object,
                StatusProcessEnum = Enum.StatusProcessEnum.Send
            });
            Assert.Equal("The Field Notifier Must Be Provided !", ex.Message);
        }
    }
}
