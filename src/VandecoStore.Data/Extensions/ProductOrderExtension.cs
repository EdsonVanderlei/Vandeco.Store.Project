

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class ProductOrderExtension
    {
        public static ProductOrderDb ToProductOrder(this ProductOrder productOrder)
        {
            return new ProductOrderDb
            {
                Order = productOrder.Order.ToOrderDb(),
                OrderId = productOrder.Order.Id,
                Price = productOrder.Price,
                Product = productOrder.Product.ToProductDb(),
                ProductId = productOrder.Product.Id,
                Quantity = productOrder.Quantity,
                Id = productOrder.Id
            };
        }
    }
}
