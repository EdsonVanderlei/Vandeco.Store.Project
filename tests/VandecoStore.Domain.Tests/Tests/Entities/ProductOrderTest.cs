using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class ProductOrderTest
    {
        [Trait("Entity", "ProductOrder")]
        [Fact]
        public void ProductOrder_Validate_ThrowsException()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            var order = new Mock<Order>().Object;

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new ProductOrder { Order = order, Price = 0, Product = product, Quantity = 10 });
            Assert.Equal("Quantity Must Be Greather Than 0", ex.Message);
        }
    }
}
