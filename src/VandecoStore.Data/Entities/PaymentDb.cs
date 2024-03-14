using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class PaymentDb : Entity
    {
        public required PaymentTypeEnum PaymentType { get; init; }
        public required int Installments { get; init; }
        public required int InstallmentsPayed { get; init; }
        public required decimal Value { get; init; }

        //EF Relations 
        public required OrderDb Order { get; init; }

        public PaymentDb() { }

        public Payment ToPayment()
        {
            return new Payment
            {
                Value = Value,
                Installments = Installments,
                Order = Order.ToOrder(),
                PaymentType = PaymentType,
                Id = Id,
            };
        }
    }
}
