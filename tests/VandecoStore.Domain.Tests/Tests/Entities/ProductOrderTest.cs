using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;

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
            var ex = Assert.Throws<DomainException>(() => new ProductOrder { Order = order, Price = 0, Product = product, Quantity = 0 });
            Assert.Equal("The Field value Must Be Greather Than 0 !", ex.Message);
        }
    }
}
