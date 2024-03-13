using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class PaymentTest
    {
        [Trait("Entity", "Payment")]
        [Fact]
        public void Payment_Validate_ThrowsException()
        {
            //Arrange && Act && Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new Payment(PaymentTypeEnum.Pix, 0, 300.00m));
            Assert.Equal("The Field Installments Must Be Greather Than 0", ex.Message);
        }

        [Trait("Entity", "Payment")]
        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        public void Payment_PayInstallment_InstallmentShouldBePay(int installmentPayed)
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, 10, 200.00m);

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
            var payment = new Payment(PaymentTypeEnum.Pix, 10, 200.00m);

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => payment.PayInstallment(installmentPayed));

            //Assert
            Assert.Equal("Installments is less than InstallmentsPayed !", ex.Message);
        }

        [Theory]
        [InlineData(1500.12, 3)]
        [InlineData(1532.12, 5)]
        [InlineData(2390.54, 4)]
        [InlineData(1234.12, 7)]
        public void Payment_CalculateTotalPayed_TheValueOfInstallmentsPayedShouldBeCalculate(decimal value, int installmentsPayed)
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, 10, value);
            payment.PayInstallment(installmentsPayed);

            //Act && Assert
            Assert.Equal((value / 10) * installmentsPayed, payment.CalculateTotalPayed());
        }


        [Theory]
        [InlineData(1500.12, 3)]
        [InlineData(1532.12, 5)]
        [InlineData(2390.54, 4)]
        [InlineData(1234.12, 7)]
        public void Payment_CalculateValuePerInstallments_InstallmentsValueShouldBeReturn(decimal value, int installments)
        {
            //Arrange
            var payment = new Payment(PaymentTypeEnum.Pix, installments, value);

            //Act && Assert
            Assert.Equal((value / installments), payment.CalculateValuePerInstallments());
        }
    }
}
