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
        }

        protected Cart() { }

        public void AddCartItem(Product product, int quantity)
        {

            var cartItemFound = CartItems.FirstOrDefault(p => p.Product.Equals(product));
            if(cartItemFound is null)
            {
                CartItems.Add(new CartItem(product,quantity));
                return;
            }
            cartItemFound.AddQuantity(quantity);
        }

        public void RemoveCartItem(Product product, int quantity)
        {
            var cartItemFound = CartItems.FirstOrDefault(p => p.Product.Equals(product)) ?? throw new InvalidOperationException("Item Not Found In Cart");
            cartItemFound.RemoveQuantity(quantity);
            if(cartItemFound.Quantity == 0)
                CartItems.Remove(cartItemFound);
        }
    }
}
