
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Collections
{
    [CollectionDefinition(nameof(UserServiceAndDomainCollection))]
    public class UserServiceAndDomainCollection : ICollectionFixture<UserServiceTestFixture>, ICollectionFixture<DomainTestFixture>
    {
    }
}
