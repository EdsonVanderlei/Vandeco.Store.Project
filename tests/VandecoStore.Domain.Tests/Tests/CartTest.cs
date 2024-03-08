using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class CartTest
    {
        [Fact]
        public void Cart_Validate_ThrowsException()
        {
            //Arrange
            var cartItem = new Mock<Cart>();

            //Act

            //Assert
        }
    }
}
