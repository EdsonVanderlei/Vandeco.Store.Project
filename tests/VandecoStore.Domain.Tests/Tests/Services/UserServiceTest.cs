using Moq;
using Moq.AutoMock;
using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    [Collection(nameof(DomainCollection))]
    public class UserServiceTest
    {
        readonly DomainTestFixture _fixture;

        public UserServiceTest(DomainTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task UserService_RegisterUser_ThrowsException()
        {
            //Arrange
            var mocker = new AutoMocker();
            var userServiceMock = mocker.CreateInstance<UserService>();
            var address = _fixture.GenerateValidAddress();
            var userRegisterDTO = new UserRegisterDTO
            {
                Address = address,
                BirthDate = DateTime.UtcNow,
                Document = "5137273723",
                Fax = "11 999121249",
                Mail = "edson@gmail.com",
                Name = "Test",
                Phone = "11 999121249"
            };
            var userRepository = mocker.GetMock<IUserRepository>();
            userRepository.Setup(p => p.ExistsWithSameDocument())

            //Act
            await userServiceMock.RegisterUser(userRegisterDTO);
            //Assert
        }
    }
}
