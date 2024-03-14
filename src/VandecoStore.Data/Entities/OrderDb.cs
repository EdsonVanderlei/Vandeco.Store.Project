using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class OrderDb : Entity
    {
        public required Guid AddressId { get; init; }
        public required Guid PaymentId { get; init; }
        public required Guid UserId { get; init; }

        //EF Relations
        public required List<ProductOrderDb> ProductOrders { get; init; }
        public required AddressDb Address { get; init; }
        public required List<OrderStatusDb> OrdersStatus { get; init; }
        public required UserDb User { get; init; }
        public required PaymentDb Payment { get; init; }

        public OrderDb() { }

        public Order ToOrder()
        {
            return new Order
            {
                Address = Address.ToAddress(),
                OrdersStatus = OrdersStatus.Select(p => p.ToOrderStatus()).ToList(),
                Payment = Payment.ToPayment(),
                ProductOrders = ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                User = User.ToUser(),
                Id = Id,
            };
        }
    }
}
