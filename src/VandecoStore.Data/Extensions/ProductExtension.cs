

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class ProductExtension
    {
        public static ProductDb ToProductDb(this Product product)
        {
            return new ProductDb
            {
                Brand = product.Brand.ToBrandDb(),
                BrandId = product.Brand.Id,
                CartItems = product.CartItems.Select(p => p.ToCartItemDb()).ToList(),
                Category = product.Category,
                Comments = product.Comments.Select(p => p.ToCommentDb()).ToList(),
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                ProductOrders = product.ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                Quantity = product.Quantity,
                Id = product.Id,
            };
        }
    }
}
