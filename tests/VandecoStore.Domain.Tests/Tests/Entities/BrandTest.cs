using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class BrandTest
    {
        [Trait("Entity", "Brand")]
        [Fact]
        public void Brand_Validate_ThrowsException()
        {
            // Act & Assert for Number
            var ex = Assert.Throws<InvalidOperationException>(() => new Brand
            {
                Description = "Descricao",
                Name = string.Empty
            }
                );
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            // Act & Assert for Number
            ex = Assert.Throws<InvalidOperationException>(() => new Brand
            {
                Description = string.Empty,
                Name = "Name",
            });
            Assert.Equal("The Field Description Must Be Provided !", ex.Message);
        }
    }
}
