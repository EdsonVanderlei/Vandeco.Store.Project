using VandecoStore.Domain.DTOS;

namespace VandecoStore.Domain.Tests.Fixture
{
    [CollectionDefinition(nameof(CatalogFixtureCollection))]
    public class CatalogFixtureCollection : IClassFixture<CatalogFixture> { }

    public class CatalogFixture : IDisposable
    {
        public ProductRegisterDTO GenerateValidProductRegisterDTO()
        {
            return new ProductRegisterDTO
            {
                BrandId = Guid.NewGuid(),
                CategoryEnum = Enum.CategoryEnum.Computer,
                Description = "Test",
                Name = "Test",
                Price = 1,
                Quantity = 2
            };
        }

        public void Dispose()
        {
        }
    }
}
