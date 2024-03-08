using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Cart : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public List<CartItem> CartItems { get; private set; } = [];

        public Cart(User user)
        {
            UserId = user.Id;
            User = user;
            CartItems = [];
        }

        public void AddCartItem(CartItem cartItem, int quantity)
        {
            var cartItemFound = CartItems.FirstOrDefault(p => p.Product.Equals(cartItem.Product));
            cartItemFound?.AddProduct(quantity);
            CartItems.Add(cartItem);
        }

        public void RemoveCartItem(CartItem cartItem, int quantity)
        {
            var cartItemFound = CartItems.FirstOrDefault(p => p.Equals(cartItem)) ?? throw new InvalidOperationException("Item Not Found In Cart");
            CartItems.Remove(cartItemFound);
        }
    }
}
