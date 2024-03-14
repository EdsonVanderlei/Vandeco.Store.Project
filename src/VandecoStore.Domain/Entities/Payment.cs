using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Payment : EntityValidation
    {
        public required PaymentTypeEnum PaymentType { get; init; }
        public required int Installments { get; init; }
        public int InstallmentsPayed { get; private set; } = 0;
        public decimal Value { get; private set; }
        public required Order Order { get; init; }

        public Payment() { }

        public decimal CalculateTotalPayed()
        {
            return (Value / Installments) * InstallmentsPayed;
        }

        public decimal CalculateValuePerInstallments()
        {
            return Value / Installments;
        }

        public void PayInstallment(int quantity)
        {
            if (Installments < InstallmentsPayed + quantity) throw new InvalidOperationException("Installments is less than InstallmentsPayed !");
            InstallmentsPayed += quantity;
        }
    }

    public enum PaymentTypeEnum
    {
        CreditCard,
        Cash,
        BankSlip,
        Pix,
        DebitCard,
    }
}
