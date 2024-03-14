using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class CartDb : Entity
    {
        public required Guid UserId { get;  init; }
        public required UserDb User { get; init; }
        public required List<CartItemDb> CartItems { get; init; }

        public CartDb() { }

        public Cart ToCart()
        {
            return new Cart
            {
                CartItems = CartItems.Select(p => p.ToCartItem()).ToList(),
                User = User.ToUser(),
                Id = Id
            };
        }
    }
}
