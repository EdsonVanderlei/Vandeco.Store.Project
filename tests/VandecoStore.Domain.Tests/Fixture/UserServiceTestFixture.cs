using VandecoStore.Domain.DTOS;

namespace VandecoStore.Domain.Tests.Fixture
{
    [CollectionDefinition(nameof(UserServiceCollection))]
    public class UserServiceCollection : ICollectionFixture<UserServiceTestFixture> { }

    public class UserServiceTestFixture : IDisposable
    {
        public UserRegisterDTO GenerateValidUserRegisterDTO()
        {
            return new UserRegisterDTO
            {
                Address = [],
                BirthDate = DateTime.UtcNow,
                Document = "5137273723",
                Fax = "11 999121249",
                Mail = "edson@gmail.com",
                Name = "Test",
                Phone = "11 999121249"
            };
        }

        public void Dispose()
        {

        }
    }
}
