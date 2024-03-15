using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Entities
{
    public class Payment : EntityValidation
    {
        public required PaymentTypeEnum PaymentType { get; init; }
        private int _installments;
        public required int Installments
        {
            get => _installments;
            init
            {
                FailIfLessThan(value,1,nameof(Installments));
                _installments = value;
            }
        }
        public int InstallmentsPayed { get; private set; } = 0;
        public required decimal Value { get; init; }
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
            if (Installments < InstallmentsPayed + quantity) throw new DomainException("Installments is less than InstallmentsPayed !");
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
