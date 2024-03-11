using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests
{
    public class PaymentTest
    {
        [Fact]
        public void Payment_Validate_ThrowsException()
        {
            //Arrange && Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new Payment(PaymentTypeEnum.Pix, 0));
            Assert.Equal("The Field Installments Must Be Greather Than 0", ex.Message);
        }

        [Fact]
        public void Payment_PayInstallment_InstallmentShouldBePay()
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, 10);

            //Act
            payment.PayInstallment(3);

            //Assert
            Assert.Equal(3, payment.InstallmentsPayed);
        }
    }
}
