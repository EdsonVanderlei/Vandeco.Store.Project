using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class CommentTest
    {
        [Trait("Entity", "Comment")]
        [Fact]
        public void Comment_Validate_ThrowsException()
        {
            //Arrange
            var product = new Mock<Product>().Object;
            var user = new Mock<User>().Object;

            //Act && Assert
            var ex = Assert.Throws<DomainException>(() =>
            new Comment
            {
                Product = product,
                Text = string.Empty,
                Title = "Produto",
                User = user
            });
            Assert.Equal("The Field Text Must Be Provided !", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Comment
            {
                Product = product,
                Text = "Text Teste",
                Title = string.Empty,
                User = user
            });
            Assert.Equal("The Field Title Must Be Provided !", ex.Message);
        }
    }
}
