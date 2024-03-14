﻿using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class ProductTest
    {
        [Trait("Entity", "Product")]
        [Fact]
        public void Product_Validate_ThrowsExceptions()
        {
            //Arrange 
            var brand = new Mock<Brand>().Object;

            //Act && Assert
            var ex = Assert.Throws<DomainException>(() => new Product
            {
                Name = string.Empty,
                Brand = brand,
                CartItems = [],
                Category = CategoryEnum.Notebook,
                Comments = [],
                Price = 1,
                ProductOrders = [],
                Quantity = 1,
            });
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            //Act && Assert
            ex = Assert.Throws<DomainException>(() => new Product
            {
                Name = "Ola",
                Brand = brand,
                CartItems = [],
                Category = CategoryEnum.Notebook,
                Comments = [],
                Price = 0,
                ProductOrders = [],
                Quantity = 1,
            });
            Assert.Equal("The Field Price Must Be Greather Than 0 !", ex.Message);
        }

        [Trait("Entity", "Product")]
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

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_UpdatePrice_ThrowsOnZeroValue()
        {
            //Arrange
            var product = new Mock<Product>().Object;

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.UpdatePrice(0));
            Assert.Equal("The Field Price Must Be Greather Than 0 !", ex.Message);
        }

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_AddComment_CommentBeAdded()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            var comment = new Mock<Comment>().Object;

            //Act
            product.AddComment(comment);

            //Assert
            Assert.Single(product.Comments);
        }

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_RemoveComment_CommentBeRemoved()
        {
            //Arrange 
            var user = new Mock<User>().Object;
            var product = new Mock<Product>().Object;
            var comment = new Comment("title", "text", product, user);
            product.AddComment(comment);

            //Act
            product.RemoveComment(comment);

            //Assert
            Assert.True(product.Comments.Count == 0);
        }

        [Fact]
        public void Product_RemoveComment_ThrowsException()
        {
            //Arrange 
            var user = new Mock<User>().Object;
            var product = new Mock<Product>().Object;
            var comment = new Comment("title", "text", product, user);
            var commentToRemove = new Comment("title", "text", product, user);
            product.AddComment(comment);

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.RemoveComment(commentToRemove));
            Assert.Equal("Comment Not Found !", ex.Message);
        }

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_AddQuantity_QuantityBeAdded()
        {
            //Arrange
            var product = new Mock<Product>().Object;

            //Act
            product.AddQuantity(10);

            //Assert 
            Assert.Equal(10, product.Quantity);
        }

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_RemoveQuantity_ThrowsWhenQuantityIsGreatherThanActual()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            product.AddQuantity(2);

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.RemoveQuantity(3));
            Assert.Equal("The Quantity To Remove Is Greather Than Actual Quantity", ex.Message);
        }

        [Trait("Entity", "Product")]
        [Fact]
        public void Product_RemoveQuantity_QuantityBeRemoved()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            product.AddQuantity(2);

            //Act
            product.RemoveQuantity(1);

            //Assert
            Assert.Equal(1, product.Quantity);
        }
    }
}
