using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class CartItem : EntityValidation
    {
        private int _quantity;
        public required int Quantity
        {
            get => _quantity;
            init
            {
                FailIfLessThan(value, 1, nameof(value));
                _quantity = value;
            }
        }
        public required Product Product { get; init; }

        public CartItem() { }

        public void AddQuantity(int quantity)
        {
            _quantity += Math.Abs(quantity);
        }

        public void RemoveQuantity(int quantity)
        {
            AssertionConcern.AssertArgumentTrue(ValidateQuantity(quantity), "The Quantity To Remove Is Greather Than Actual Quantity !");
            _quantity -= Math.Abs(quantity);

        }

        public bool ValidateQuantity(int quantity)
        {
            return Quantity - Math.Abs(quantity) >= 0;
        }
    }
}
