using VandecoStore.Domain.ObjectValues;
using VandecoStore.Domain.ObjectValues.Exceptions;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class MailTest
    {
        [Trait("ValueObject", "Mail")]
        [Theory]
        [InlineData("pagare@")]
        [InlineData("edson@dad")]
        [InlineData("ww@ww@.com")]
        public void Mail_Validate_ThrowsException(string mailAddress)
        {
            //Arrange && Act && Assert
            var ex = Assert.Throws<InvalidEmailException>(() => new Mail(mailAddress));
            Assert.Equal($"The Email Adress {mailAddress} is invalid", ex.Message);
        }
    }
}
