using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class BrandTest
    {
        [Trait("Entity", "Brand")]
        [Fact]
        public void Brand_Validate_ThrowsException()
        {
            // Act & Assert for Number
            var ex = Assert.Throws<InvalidOperationException>(() => new Brand(string.Empty, "Um Monitor Acer"));
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            // Act & Assert for Number
            ex = Assert.Throws<InvalidOperationException>(() => new Brand("Acer", string.Empty));
            Assert.Equal("The Field Description Must Be Provided !", ex.Message);
        }
    }
}
