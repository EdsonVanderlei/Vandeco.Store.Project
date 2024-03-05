using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Cart : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public List<CartItem> CartItems { get; private set; }

        public Cart(User user)
        {
            UserId = user.Id;
            User = user;
            CartItems = [];
        }
    }

    public class CartItem : Entity
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        protected CartItem() { }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Validate();
        }

        public void AddProduct(int quantity)
        {
            Quantity += Math.Abs(quantity);
        }

        public void RemoveProduct(int quantity)
        {
            AssertionConcern.AssertArgumentTrue(ValidateQuantity(quantity), "The quantity to remove is greather than actual quantity !");
            Quantity -= Math.Abs(quantity);
        }

        private bool ValidateQuantity(int quantity)
        {
            return Product.Quantity - Math.Abs(quantity) <= 0;
        }
        
        private void Validate()
        {
            AssertionConcern.AssertArgumentTrue(Quantity > 0, "The Field Quantity Must Be Greather than 0 !");
        }
    }
}
