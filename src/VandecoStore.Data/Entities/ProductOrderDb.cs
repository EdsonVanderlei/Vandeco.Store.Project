using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class ProductOrderDb : Entity
    {
        public required Guid ProductId { get; init; }
        public required Guid OrderId { get; init; }
        public required int Quantity { get; init; }
        public required decimal Price { get; init; }

        //EF Relations 
        public required OrderDb Order { get; init; }
        public required ProductDb Product { get; init; }

        public ProductOrderDb() { }

        public ProductOrder ToProductOrder()
        {
            return new ProductOrder
            {
                Order = Order.ToOrder(),
                Price = Price,
                Product = Product.ToProduct(),
                Quantity = Quantity,
                Id = Id
            };
        }
    }
}
