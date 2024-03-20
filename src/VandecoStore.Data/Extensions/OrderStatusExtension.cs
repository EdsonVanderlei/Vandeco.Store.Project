

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class OrderStatusExtension
    {
        public static OrderStatusDb ToOrderStatusDb(this OrderStatus orderStatus)
        {
            return new OrderStatusDb
            {
                CreatedAt = orderStatus.CreatedAt,
                Notifier = orderStatus.Notifier,
                OrderId = orderStatus.Order.Id,
                StatusProcessEnum = orderStatus.StatusProcessEnum,
                Order = orderStatus.Order.ToOrderDb(),
                Id = orderStatus.Id,
            };
        }
    }
}
