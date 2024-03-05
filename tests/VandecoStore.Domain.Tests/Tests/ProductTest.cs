using Moq;
using System.Diagnostics;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class ProductTest
    {
        [Fact]
        public void Product_WithValidParameters_Instance()
        {
            //Arrange 
            var name = "Pc Gamer Gladiator LVL II";
            var price = 123.98m;
            var quantity = 10;
            var category = Category.Computer;
            var description = "Pc Gamer Ryzen 5 RTX 4090TI 16GB RAM";
            var brand = new Mock<Brand>().Object;

            //Act
            var product = new Product(name, price, quantity, category, description, brand);

            //Assert
            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(quantity, product.Quantity);
            Assert.Equal(category, product.Category);
            Assert.Equal(description, product.Description);
            Assert.Equal(brand, product.Brand);
        }



        [Theory]
        [InlineData("", "description", 10.32)]
        [InlineData("name", "", 10.32)]
        [InlineData("name", "description", 0)]
        public void Product_WithInvalidParameters_Throws(string name, string description, decimal price)
        {
            //Arrange 
            var brand = new Mock<Brand>().Object;

            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => new Product(name, price, 0, Category.Mouse, description, brand));
            ;
        }

        [Theory]
        [InlineData(120.23)]
        [InlineData(12.76)]
        [InlineData(1.23)]
        [InlineData(12320.23)]
        public void Product_UpdatePrice_ChangePrice(decimal price)
        {
            //Arrange
            var product = new Mock<Product>().Object;

            //Act
            product.UpdatePrice(price);

            //Assert
            Assert.Equal(price, product.Price);
        }

        [Fact]
        public void Product_UpdatePrice_ThrowsOnZeroValue()
        {
            //Arrange
            var product = new Mock<Product>().Object;

            //Act
            product.UpdatePrice(0);

            //Assert
            Assert.Throws<InvalidOperationException>( () => product.UpdatePrice(0));
        }

        [Fact]
        public void Product_RemoveComment_CommentBeRemoved()
        {
            //Arrange 
            var product = new Mock<Product>().Object;
            var comment = new Mock<Comment>().Object;
            product.AddComment(comment);

            //Act
            product.RemoveComment(comment);

            //Assert
            Assert.Equal([], product.Comments);
        }
    }
}
