using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Cart : EntityValidation
    {
        public required User User { get; init; }
        public required List<CartItem> CartItems { get; init; }

        public Cart() { }

        public void AddCartItem(Product product, int quantity)
        {

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
            cartItemFound.AddQuantity(quantity);
        }

        public void RemoveCartItem(Product product, int quantity)
        {
            var cartItemFound = CartItems.FirstOrDefault(p => p.Product.Equals(product)) ?? throw new InvalidOperationException("Item Not Found In Cart");
            cartItemFound.RemoveQuantity(quantity);
            if (cartItemFound.Quantity == 0)
                CartItems.Remove(cartItemFound);
        }
    }
}
