using VandecoStore.Domain.Entities;

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
            var ex = Assert.Throws<InvalidOperationException>(() => new Mail(mailAddress));
            Assert.Equal("Mail Address Not Valid !", ex.Message);
        }
    }
}
