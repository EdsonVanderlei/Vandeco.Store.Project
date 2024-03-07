using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class AddressTests
    {

        public AddressTests(){}

        [Trait("Entity", "Address")]
        [Fact]
        public void Address_Validate_ThrowsArgumentException()
        {
            //Arrange 
            var user = new Mock<User>().Object;

            // Act & Assert for Street
            var ex = Assert.Throws<InvalidOperationException>(() => new Address(string.Empty, "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park", user));
            Assert.Equal("The Field Street Must be provided!", ex.Message);

            // Act & Assert for ZipCode
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", string.Empty, "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park", user));
            Assert.Equal("The Field ZipCode Must be provided!", ex.Message);

            // Act & Assert for NeighboardHood
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", string.Empty, "Metropolis", "United States", "NY", "10A", "Near the park", user));
            Assert.Equal("The Field NeighboardHood Must be provided!", ex.Message);

            // Act & Assert for City
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", "Downtown", string.Empty, "United States", "NY", "10A", "Near the park", user));
            Assert.Equal("The Field City Must be provided!", ex.Message);

            // Act & Assert for Country
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", "Downtown", "Metropolis", string.Empty, "NY", "10A", "Near the park", user));
            Assert.Equal("The Field Country Must be provided!", ex.Message);

            // Act & Assert for State
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", "Downtown", "Metropolis", "United States", string.Empty, "10A", "Near the park", user));
            Assert.Equal("The Field State Must be provided!", ex.Message);

            // Act & Assert for Number
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", string.Empty, "Near the park", user));
            Assert.Equal("The Field Number Must be provided!", ex.Message);

            // Act & Assert for Complement
            ex = Assert.Throws<InvalidOperationException>(() => new Address("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", string.Empty, user));
            Assert.Equal("The Field Complement Must be provided!", ex.Message);
        }

        [Trait("Entity", "Address")]
        [Fact]
        public void Address_UpdateAddress_AddressMustBeUpdated()
        {
            //Arrange 
            var user = new Mock<User>().Object;
            var address1 = new Mock<Address>().Object;
            var address = new Address("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park", user);

            //Act
            address.UpdateAddress(address1);

            //Assert
            Assert.Equal(address.City, address1.City);
            Assert.Equal(address.Street, address1.Street);
            Assert.Equal(address.ZipCode, address1.ZipCode);
            Assert.Equal(address.Country, address1.Country);
            Assert.Equal(address.State, address1.State);
            Assert.Equal(address.NeighboardHood, address1.NeighboardHood);
            Assert.Equal(address.Number, address1.Number);
            Assert.Equal(address.Complement, address.Number);
        }
    }
}