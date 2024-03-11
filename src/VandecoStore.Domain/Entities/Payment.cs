using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Payment : Entity
    {
        public PaymentTypeEnum PaymentType { get; private set; }
        public int Installments { get; private set; }
        public int InstallmentsPayed { get; private set; }

        //EF Relations 
        public Order Order { get; private set; }

        public Payment(PaymentTypeEnum paymentType, int installments)
        {
            PaymentType = paymentType;
            Installments = installments;
            InstallmentsPayed = 0;
            Validate();
        }

        protected Payment() { }

        public void PayInstallment(int quantity)
        {
            if (Installments < InstallmentsPayed + quantity) throw new InvalidOperationException("Installments is less than InstallmentsPayed !");
            InstallmentsPayed += quantity;
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentTrue(Installments > 0, "The Field Installments Must Be Greather Than 0");
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
