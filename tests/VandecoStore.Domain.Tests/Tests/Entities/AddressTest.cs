using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class AddressTests
    {
        public AddressTests() { }

        [Trait("Entity", "Address")]
        [Fact]
        public void Address_Validate_ThrowsException()
        {
            // Arrange 
            var user = new Mock<User>().Object;

            // Act & Assert for Street
            var ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = "United States",
                NeighboardHood = "DownTown",
                Number = "10A",
                User = user,
                State = "New York",
                Street = string.Empty,
                ZipCode = "031203",
            });
            Assert.Equal("The Field Street Must Be Provided !", ex.Message);

            // Act & Assert for ZipCode
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = "United States",
                NeighboardHood = "DownTown",
                Number = "10A",
                User = user,
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = string.Empty,
            });
            Assert.Equal("The Field ZipCode Must Be Provided !", ex.Message);

            // Act & Assert for NeighboardHood
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = "United States",
                NeighboardHood = string.Empty,
                Number = "10A",
                State = "New York",
                User = user,
                Street = "Rua Nova York",
                ZipCode = "0293123",
            });
            Assert.Equal("The Field NeighboardHood Must Be Provided !", ex.Message);

            // Act & Assert for City
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = string.Empty,
                Complement = "Near the park",
                Country = "United States",
                User = user,
                NeighboardHood = "DownTown",
                Number = "10A",
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = "031203",
            });
            Assert.Equal("The Field City Must Be Provided !", ex.Message);

            // Act & Assert for Country
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = string.Empty,
                NeighboardHood = "DownTown",
                User = user,
                Number = "10A",
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = "031203",
            });
            Assert.Equal("The Field Country Must Be Provided !", ex.Message);

            // Act & Assert for State
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = "United States",
                NeighboardHood = "DownTown",
                User = user,
                Number = "10A",
                State = string.Empty,
                Street = "Rua Nova York",
                ZipCode = "031203",
            });
            Assert.Equal("The Field State Must Be Provided !", ex.Message);

            // Act & Assert for Number
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = "Near the park",
                Country = "United States",
                NeighboardHood = "DownTown",
                Number = string.Empty,
                State = "New York",
                User = user,
                Street = "Rua Nova York",
                ZipCode = "031203",
            });
            Assert.Equal("The Field Number Must Be Provided !", ex.Message);

            // Act & Assert for Complement
            ex = Assert.Throws<DomainException>(() => new Address
            {
                City = "123456",
                Complement = string.Empty,
                Country = "United States",
                NeighboardHood = "DownTown",
                User = user,
                Number = "10A",
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = "031203",
            });
            Assert.Equal("The Field Complement Must Be Provided !", ex.Message);
        }

        [Trait("Entity", "Address")]
        [Fact]
        public void Address_UpdateAddress_AddressMustBeUpdated()
        {
            // Arrange 
            var user = new Mock<User>().Object;
            var address1 = new Address
            {
                User = user,
                City = "123456",
                Complement = "Complement",
                Country = "United States",
                NeighboardHood = "DownTown",
                Number = "10A",
                State = "New York",
                Street = "Rua Nova York",
                ZipCode = "031203",
            };
            var address = new Mock<Address>().Object;

            // Act
            address.UpdateAddress(address1);

            // Assert
            Assert.Equal(address1.City, address.City);
            Assert.Equal(address1.Street, address.Street);
            Assert.Equal(address1.ZipCode, address.ZipCode);
            Assert.Equal(address1.Country, address.Country);
            Assert.Equal(address1.State, address.State);
            Assert.Equal(address1.NeighboardHood, address.NeighboardHood);
            Assert.Equal(address1.Number, address.Number);
            Assert.Equal(address1.Complement, address.Complement);
        }
    }
}
