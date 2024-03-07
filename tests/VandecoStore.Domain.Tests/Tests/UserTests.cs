using Moq;
using Moq.AutoMock;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests
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

        [Trait("Entity","User")]
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
        public void User_UpdatePhone_PhoneHasBeenUpdated()
        {
            //Arrange


            //Act


            //Assert
        }
    }
}
