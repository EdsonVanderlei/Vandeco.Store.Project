using Moq;
using Moq.AutoMock;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Interfaces;
using VandecoStore.Domain.Services;
using VandecoStore.Domain.Tests.Collections;
using VandecoStore.Domain.Tests.Fixture;

namespace VandecoStore.Domain.Tests.Tests.Services
{
    [Collection(nameof(UserServiceAndDomainCollection))]
    public class UserServiceTest
    {
        readonly DomainTestFixture _domainFixture;
        readonly UserServiceTestFixture _userServiceFixture;

        public UserServiceTest(DomainTestFixture domainFixture, UserServiceTestFixture userServiceFixture)
        {
            _domainFixture = domainFixture;
            _userServiceFixture = userServiceFixture;
        }

        [Trait("Services", "User")]
        [Fact]
        public async Task UserService_RegisterUser_ThrowsException()
        {
            //Arrange
            var address = _domainFixture.GenerateValidAddress();
            var userRegisterDTO = _userServiceFixture.GenerateValidUserRegisterDTO();
            var mocker = new AutoMocker();
            var userRepository = mocker.GetMock<IUserRepository>();
            userRepository.Setup(p => p.ExistsWithSameDocument(It.IsAny<string>())).ReturnsAsync(true);
            var userServiceMock = new UserService(userRepository.Object);

            //Act && Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => userServiceMock.RegisterUser(userRegisterDTO));
            Assert.Equal("User Already Exists !", ex.Message);
        }

        [Trait("Services", "User")]
        [Fact]
        public async Task UserService_RegisterUser_UserShouldBeRegister()
        {
            //Arrange
            var address = _domainFixture.GenerateValidAddress();
            var userRegisterDTO = _userServiceFixture.GenerateValidUserRegisterDTO();
            var mocker = new AutoMocker();
            var userRepository = mocker.GetMock<IUserRepository>();
            userRepository.Setup(p => p.ExistsWithSameDocument(It.IsAny<string>())).ReturnsAsync(false);
            var userService = new UserService(userRepository.Object);

            //Act 
            await userService.RegisterUser(userRegisterDTO);

            // Assert
            userRepository.Verify(p => p.Add(It.IsAny<User>()), Times.Once);
        }

        [Trait("Services", "User")]
        [Fact]
        public async Task UserService_DeleteUser_ThrowsException()
        {
            //Arrange
            var user = _domainFixture.GenerateValidUser();
            var order = new Mock<Order>().Object;
            order.UpdateOrderStatus(
                    "Edson",
                    StatusProcessEnum.Processing
            );
            user.AddOrder(order);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(user);
            var userService = new UserService(userRepository.Object);

            // Act && Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => userService.DeleteUser(user.Id));
            Assert.Equal("Open Orders, Cannot Delete The User !", ex.Message);
        }

        [Trait("Services", "User")]
        [Fact]
        public async Task UserService_DeleteUser_UserShouldBeDelete()
        {
            //Arrange
            var user = _domainFixture.GenerateValidUser();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(p => p.GetById(It.IsAny<Guid>())).ReturnsAsync(user);
            var userService = new UserService(userRepository.Object);

            //Act
            await userService.DeleteUser(user.Id);

            //Assert
            userRepository.Verify(p => p.Remove(It.IsAny<Guid>()), Times.Once);

        }
    }
}
