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

            return new User
            {
                BirthDate = DateTime.Now,
                Cart  = new Cart
                {
                    CartItems = [],
                },
                Document = document,
                Mail = mail,
                Name = "Edson",
                Phone = phone,
            };
        }

        public ProductOrder GenerateValidProductOrder(int quantity, decimal price)
        {
            var product = GenerateValidProduct(quantity, price);
            return new ProductOrder
            {
                Order = new Mock<Order>().Object,
                Price = price,
                Product = product,
                Quantity = quantity,
            };
        }

        public Product GenerateValidProduct(int quantity, decimal price)
        {
            return new Product
            {
                Name = "Produto tal",
                ProductOrders = [],
                Quantity = quantity,
                Brand = new Mock<Brand>().Object,
                Price = price,
                CartItems = [],
                Category = CategoryEnum.Notebook,
                Comments = [],
            };
        }

        public List<Address> GenerateValidAddress()
        {
            var user = new Mock<User>();
            return new List<Address> {  new() {
                User = user.Object,
                City = "123456",
                Complement = "Complement",
                Country = "United States",
                NeighboardHood = "DownTown",
                Number = "10A",
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = "031203",
            } };
        }
        public Document GenerateValidDocument()
        {
            return new Document("5142533652");
        }

        public Mail GenerateValidMail()
        {
            return new Mail("edsonddd@outlook.com");
        }

        public Phone GenerateValidPhone()
        {
            return new Phone( "11", "999932913");
        }

        public void Dispose()
        {

        }
    }
}
