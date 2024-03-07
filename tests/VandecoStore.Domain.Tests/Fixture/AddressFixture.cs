using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Fixture
{
    [CollectionDefinition(nameof(DomainCollection))]
    public class DomainCollection : ICollectionFixture<DomainTestFixture> { }

    public class DomainTestFixture : IDisposable
    {
        public User GenerateValidUser()
        {
            var mail = GenerateValidMail();
            var phone = GenerateValidPhone();
            var address = GenerateValidAddress();
            var document = GenerateValidDocument();

            return new User("Nome", mail, phone, new DateTime(), address, document);
        }

        public Address GenerateValidAddress()
        {
            var user = new Mock<User>();
            return new Address("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park", user.Object);
        }

        public Document GenerateValidDocument()
        {
            return new Document("51373746874");
        }

        public Mail GenerateValidMail()
        {
            return new Mail("edsonddd@outlook.com");
        }

        public Phone GenerateValidPhone()
        {
            return new Phone(11, 55, "999516685");
        }

        public void Dispose()
        {
            
        }
    }
}
