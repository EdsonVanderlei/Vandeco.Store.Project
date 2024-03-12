using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class PaymentTest
    {
        [Trait("Entity", "Payment")]
        [Fact]
        public void Payment_Validate_ThrowsException()
        {
            //Arrange && Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new Payment(PaymentTypeEnum.Pix, 0));
            Assert.Equal("The Field Installments Must Be Greather Than 0", ex.Message);
        }

        [Trait("Entity","Payment")]
        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        public void Payment_PayInstallment_InstallmentShouldBePay(int installmentPayed)
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, 10);

            //Act
            payment.PayInstallment(installmentPayed);

            //Assert
            Assert.Equal(installmentPayed, payment.InstallmentsPayed);
        }

        [Trait("Entity", "Payment")]
        [Theory]
        [InlineData(11)]
        [InlineData(15)]
        [InlineData(20)]
        public void Payment_PayInstallment_ThrowsException(int installmentPayed)
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, 10);

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => payment.PayInstallment(installmentPayed));

            //Assert
            Assert.Equal("Installments is less than InstallmentsPayed !", ex.Message);
        }
    }
}
