

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class CartItemExtension
    {
        public static CartItemDb ToCartItemDb(this CartItem cartItem)
        {
            return new CartItemDb
            {
                Product = cartItem.Product.ToProductDb(),
                ProductId = cartItem.Product.Id,
                Quantity = cartItem.Quantity,
                Id = cartItem.Id
            };
        }
    }
}
