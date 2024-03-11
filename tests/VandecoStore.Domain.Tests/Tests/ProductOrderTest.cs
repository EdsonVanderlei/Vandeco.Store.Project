using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class ProductOrderTest
    {
        [Fact]
        public void ProductOrder_Validate_ThrowsException()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            var order = new Mock<Order>().Object;

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new ProductOrder(order, product, 0));
            Assert.Equal("Quantity Must Be Greather Than 0", ex.Message);
        }
    }
}
