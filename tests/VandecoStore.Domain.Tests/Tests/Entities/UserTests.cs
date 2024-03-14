using Moq;
using Moq.AutoMock;
using System.Net;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.ObjectValues;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    [Collection(nameof(DomainCollection))]
    public class UserTests
    {
        private readonly DomainTestFixture _domainTestFixture;
        private readonly AutoMocker _mocker;

        public UserTests(DomainTestFixture domainTestFixture)
        {
            _mocker = new AutoMocker();
            _domainTestFixture = domainTestFixture;
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_Validate_ThrowsException()
        {
            //Arrange
            var mail = _domainTestFixture.GenerateValidMail();
            var phone = _domainTestFixture.GenerateValidPhone();
            var address = _domainTestFixture.GenerateValidAddress();
            var document = _domainTestFixture.GenerateValidDocument();

            //Act & Assert
            var ex = Assert.Throws<DomainException>(() => new User
            {
                Addresses = [],
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Comments = [],
                Document = document,
                Mail = mail,
                Name = string.Empty,
                Orders = [],
                Phone = phone,
            });
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            //Act & Assert
            ex = Assert.Throws<DomainException>(() => new User
            {
                Addresses = [],
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Comments = [],
                Document = document,
                Mail = mail,
                Name = "Edson",
                Orders = [],
                Phone = string.Empty,
            });
            Assert.Equal("The Field PhoneNumber Must Be Provided !", ex.Message);
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_HasFaxPhone_ReturnFalse()
        {
            //Arrange
            var user = new Mock<User>().Object;

            //Act && Assert
            Assert.False(user.HasFaxPhone());
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_UpdatePhone_PhoneShouldBeUpdated()
        {
            //Arrange
            var mail = _domainTestFixture.GenerateValidMail();
            var phone = _domainTestFixture.GenerateValidPhone();
            var address = _domainTestFixture.GenerateValidAddress();
            var document = _domainTestFixture.GenerateValidDocument();

            var user = new User
            {
                Addresses = [],
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Comments = [],
                Document = document,
                Mail = mail,
                Name = phone,
                Orders = [],
                Phone = "11 99 993128321",
            };

            Phone phoneToUpdate = "56 22 999999999";

            //Act
            user.UpdatePrincipalPhone(phoneToUpdate);

            //Assert
            Assert.Equal("22", user.Phone.AreaCode);
            Assert.Equal("56", user.Phone.CountryCode);
            Assert.Equal("999999999", user.Phone.PhoneNumber);
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_UpdateFaxPhone_FaxPhoneShoulbBeUpdated()
        {
            //Arrange
            var user = new Mock<User>().Object;
            Phone phone = "56 22 999999999";

            //Act
            user.UpdateFaxPhone(phone);

            //Assert
            Assert.Equal("22", user.Fax?.AreaCode);
            Assert.Equal("56", user.Fax?.CountryCode);
            Assert.Equal("999999999", user.Fax?.PhoneNumber);
        }
    }
}
