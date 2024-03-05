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

        [Fact]
        public void User_WithValidParameters_CreateInstance()
        {
            //Arrange
            var mail = _domainTestFixture.GenerateValidMail();
            var phone = _domainTestFixture.GenerateValidPhone();
            var address = _domainTestFixture.GenerateValidAddress();
            var document = _domainTestFixture.GenerateValidDocument();

            //Act
            var user = new User("Edson Vanderlei", mail, phone, new DateTime(), address, document);

            //Assert
            Assert.Equal("Edson Vanderlei", user.Name);
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void User_WithInvalidParameters_ThrowsError(string name)
        {
            //Arrange
            var mail = _domainTestFixture.GenerateValidMail();
            var phone = _domainTestFixture.GenerateValidPhone();
            var address = _domainTestFixture.GenerateValidAddress();
            var document = _domainTestFixture.GenerateValidDocument();

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => new User(name, mail, phone, new DateTime(), address, document));
        }
    }
}
