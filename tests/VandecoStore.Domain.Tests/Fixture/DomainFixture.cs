using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.ObjectValues;

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

        public ProductOrder GenerateValidProductOrder(int quantity, decimal price)
        {
            var product = GenerateValidProduct(quantity,price);
            return new ProductOrder(new Mock<Order>().Object, product, quantity);
        }

        public Product GenerateValidProduct(int quantity,decimal price)
        {
            return new Product("Product", price, quantity, CategoryEnum.Computer, "Description", new Brand("Marca 1", "Description"));
        }

        public List<Address> GenerateValidAddress()
        {
            var user = new Mock<User>();
            return new List<Address> { new("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park", user.Object) };
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
