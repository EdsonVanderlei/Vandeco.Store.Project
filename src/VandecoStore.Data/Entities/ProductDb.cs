using VandecoStore.Core;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Data.Entities
{
    public class ProductDb : Entity
    {
        public required Guid BrandId { get; init; }
        public required string Name { get; init; }
        public required decimal Price { get; init; }
        public required int Quantity { get; init; }
        public required CategoryEnum Category { get; init; }
        public required string Description { get; init; }

        //EF relation
        public required BrandDb Brand { get; init; }
        public required List<CommentDb> Comments { get; init; }
        public required List<ProductOrderDb> ProductOrders { get; init; }
        public required List<CartItemDb> CartItems { get; init; }

        public ProductDb() { }

        public Product ToProduct()
        {
            return new Product
            {
                Brand = Brand.ToBrand(),
                CartItems = CartItems.Select(p => p.ToCartItem()).ToList(),
                Category = Category,
                Comments = Comments.Select(p => p.ToComment()).ToList(),
                Name = Name,
                Price = Price,
                ProductOrders = ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                Quantity = Quantity,
                Id = Id,
            };
        }
    }
}
