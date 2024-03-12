using Moq;
using Moq.AutoMock;
using System.Net;
using VandecoStore.Domain.Entities;
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
            var ex = Assert.Throws<InvalidOperationException>(() => new User(string.Empty, mail, phone, new DateTime(), address, document));
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            //Act & Assert
            ex = Assert.Throws<InvalidOperationException>(() => new User("Nome", mail, null, new DateTime(), address, document));
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
            var user = new User("Nome", mail, phone, new DateTime(), address, document);
            var phoneToUpdate = new Phone(22, 56, "999999999");

            //Act
            user.UpdatePrincipalPhone(phoneToUpdate);

            //Assert
            Assert.Equal(22, user.Phone.AreaCode);
            Assert.Equal(56, user.Phone.CountryCode);
            Assert.Equal("999999999", user.Phone.PhoneNumber);
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_UpdateFaxPhone_FaxPhoneShoulbBeUpdated()
        {
            //Arrange
            var user = new Mock<User>().Object;
            var phone = new Phone(22, 56, "999999999");

            //Act
            user.UpdateFaxPhone(phone);

            //Assert
            Assert.Equal(22, user.Fax.AreaCode);
            Assert.Equal(56, user.Fax.CountryCode);
            Assert.Equal("999999999", user.Fax.PhoneNumber);
        }
    }
}
