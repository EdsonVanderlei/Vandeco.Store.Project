using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Entities
{
    public class Cart : EntityValidation
    {
        public User User { get; init; }
        public List<CartItem> CartItems { get; init; } = [];

        public Cart() { }

        public void ClearCart()
        {
            CartItems.Clear();
        }

        public void UpdateCartItems(Product product, int quantity)
        {
            if (quantity < 0) throw new DomainException("The Field Must Be Greather Than 0 !");
            var cartItemFound = CartItems.FirstOrDefault(p => p.Product.Equals(product));
            if (cartItemFound is null)
            {
                CartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
                return;
            }
            cartItemFound.UpdateQuantity(quantity);
            if (cartItemFound.Quantity == 0)
                CartItems.Remove(cartItemFound);
        }
    }
}
