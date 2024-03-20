

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class OrderExtension
    {
        public static OrderDb ToOrderDb(this Order order)
        {
            return new OrderDb
            {
                Address = order.Address.ToAddressDb(),
                AddressId = order.Address.Id,
                OrdersStatus = order.OrdersStatus.Select(p => p.ToOrderStatusDb()).ToList(),
                Payment = order.Payment.ToPaymentDb(),
                PaymentId = order.Payment.Id,
                ProductOrders = order.ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                User = order.User.ToUserDb(),
                UserId = order.User.Id,
                Id = order.Id,
            };
        }
    }
}
