

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class CartExtension
    {
        public static CartDb ToCartDb(this Cart cart)
        {
            return new CartDb
            {
                CartItems = cart.CartItems.Select(p => p.ToCartItemDb()).ToList(),
                User = cart.User.ToUserDb(),
                UserId = cart.User.Id,
                Id = cart.Id
            };
        }
    }
}
