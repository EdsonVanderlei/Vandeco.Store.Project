

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class PaymentExtension
    {
        public static PaymentDb ToPaymentDb(this Payment payment)
        {
            return new PaymentDb
            {
                Order = payment.Order.ToOrderDb(),
                Installments = payment.Installments,
                InstallmentsPayed = payment.InstallmentsPayed,
                PaymentType = payment.PaymentType,
                Value = payment.Value,
                Id = payment.Id
            };
        }
    }
}
