using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class CommentTest
    {
        [Fact]
        public void Comment_Validate_ThrowsException()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            var user = new Mock<User>().Object;

            //Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new Comment("Produto", string.Empty, product, user));
            Assert.Equal("The Field Text Must Be Provided!", ex.Message);

            ex = Assert.Throws<InvalidOperationException>(() => new Comment(string.Empty, "Text", product, user));
            Assert.Equal("The Field Title Must Be Provided!", ex.Message);
        }
    }
}
