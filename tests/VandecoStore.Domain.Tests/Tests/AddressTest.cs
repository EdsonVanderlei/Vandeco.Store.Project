using Moq;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class AddressTests
    {
        readonly User _user;

        public AddressTests()
        {
            _user = new Mock<User>().Object;
        }


        [Fact]
        public void Address_WithValidParameters_CreateInstance()
        {
            //Arrange
            string street = "123 Main St";
            string zipCode = "12345";
            string neighboardHood = "Downtown";
            string city = "Metropolis";
            string country = "USA";
            string state = "NY";
            string number = "10";
            string complement = "Apt 101";

            //Act 
            var address = new Address(street, zipCode, neighboardHood, city, country, state, number, complement, _user);

            //Assert
            Assert.NotNull(address);
            Assert.Equal(street, address.Street);
            Assert.Equal(zipCode, address.ZipCode);
            Assert.Equal(neighboardHood, address.NeighboardHood);
            Assert.Equal(city, address.City);
            Assert.Equal(country, address.Country);
            Assert.Equal(state, address.State);
            Assert.Equal(number, address.Number);
            Assert.Equal(complement, address.Complement);
        }

        [Theory]
        [InlineData("", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park")]
        [InlineData("123 Main St", "", "Downtown", "Metropolis", "United States", "NY", "10A", "Near the park")]
        [InlineData("123 Main St", "12345", "", "Metropolis", "United States", "NY", "10A", "Near the park")]
        [InlineData("123 Main St", "12345", "Downtown", "", "United States", "NY", "10A", "Near the park")]
        [InlineData("123 Main St", "12345", "Downtown", "Metropolis", "", "NY", "10A", "Near the park")]
        [InlineData("123 Main St", "12345", "Downtown", "Metropolis", "United States", "", "10A", "Near the park")]
        [InlineData("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "", "Near the park")]
        [InlineData("123 Main St", "12345", "Downtown", "Metropolis", "United States", "NY", "10A", "")]
        public void Address_WithInvalidParameters_ThrowsArgumentException(string street, string zipCode, string neighborhood, string city, string country, string state, string number, string complement)
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidOperationException>(() => new Address(street, zipCode, neighborhood, city, country, state, number, complement, _user));
        }
    }
}