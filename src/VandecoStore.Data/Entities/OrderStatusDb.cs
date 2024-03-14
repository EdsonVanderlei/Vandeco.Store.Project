using VandecoStore.Core;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Data.Entities
{
    public class OrderStatusDb : Entity
    {
        public required Guid OrderId { get; init; }
        public required string Notifier { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required StatusProcessEnum StatusProcessEnum { get; init; }

        //EF RELATIONS
        public required OrderDb Order { get; init; }

        public OrderStatusDb() { }

        public OrderStatus ToOrderStatus()
        {
            return new OrderStatus
            {
                Notifier = Notifier,
                Order = Order.ToOrder(),
                StatusProcessEnum = StatusProcessEnum,
                Id = Id,
            };
        }
    }
}
