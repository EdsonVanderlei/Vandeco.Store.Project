using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class MailTest
    {
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
