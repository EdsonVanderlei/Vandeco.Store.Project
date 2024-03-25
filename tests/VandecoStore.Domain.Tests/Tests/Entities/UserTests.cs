using Moq;
using Moq.AutoMock;
using System.Net;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.ObjectValues;
using VandecoStore.Domain.ObjectValues.Exceptions;
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
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Document = document,
                Mail = mail,
                Name = string.Empty,
                Phone = phone,
            });
            Assert.Equal("The Field Name Must Be Provided !", ex.Message);

            //Act & Assert
            var exPhone = Assert.Throws<InvalidPhoneException>(() => new User
            {
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Document = document,
                Mail = mail,
                Name = "Edson",
                Phone = string.Empty,
            });
            Assert.Equal("The Phone Number is invalid", exPhone.Message);
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
                BirthDate = DateTime.Now,
                Cart = new Mock<Cart>().Object,
                Document = document,
                Mail = mail,
                Name = phone,
                Phone = "11 993128321",
            };

            Phone phoneToUpdate = "22 999999999";

            //Act
            user.UpdatePrincipalPhone(phoneToUpdate);

            //Assert
            Assert.Equal("22", user.Phone.AreaCode);
            Assert.Equal("999999999", user.Phone.PhoneNumber);
        }

        [Trait("Entity", "User")]
        [Fact]
        public void User_UpdateFaxPhone_FaxPhoneShoulbBeUpdated()
        {
            //Arrange
            var user = new Mock<User>().Object;
            Phone phone = "11 999516675";

            //Act
            user.UpdateFaxPhone(phone);

            //Assert
            Assert.Equal("11", user.Fax?.AreaCode);
            Assert.Equal("999516675", user.Fax?.PhoneNumber);
        }

        [Trait("Entity", "User")]
        [Theory]
        [InlineData(StatusProcessEnum.Delivered, false)]
        [InlineData(StatusProcessEnum.Approved, true)]
        [InlineData(StatusProcessEnum.Processing, true)]
        [InlineData(StatusProcessEnum.Preparing, true)]
        [InlineData(StatusProcessEnum.Send, true)]
        public void User_HasDeliveryOrder_ShouldBeTrue(StatusProcessEnum statusProcessEnum, bool valueFinal)
        {
            //Arrange
            var user = new Mock<User>().Object;
            var order = new Mock<Order>().Object;
            order.UpdateOrderStatus("Edson", statusProcessEnum);
            user.AddOrder(order);

            //Act && Assert
            Assert.Equal(valueFinal,user.HasDeliveryOrder());
        }

        [Fact]
        public void User_AddAddress_ShouldBeAdded()
        {
            //Arrange
            var address  = _domainTestFixture.GenerateValidAddress();
            var user = new Mock<User>().Object;

            //Act 
            user.AddAddress(address.First());

            //Assert
            Assert.Single(user.Addresses);
        }
    }
}
