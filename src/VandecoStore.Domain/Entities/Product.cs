using VandecoStore.Core;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain.Entities
{
    public class Product : EntityValidation
    {
        private string _name;
        public required string Name
        {
            get => _name;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _name = value;
            }
        }

        private decimal _price;
        public required decimal Price
        {
            get => _price;
            init
            {
                FailIfLessThan(value, 0.01m, nameof(value));
                _price = value;
            }
        }
        private int _quantity;
        public required int Quantity
        {
            get => _quantity;
            init
            {
                _quantity = value;
            }
        }
        public required CategoryEnum Category { get; init; }
        private string _description;
        public string Description
        {
            get => _description;
            init
            {
                _description = value;
            }
        }
        public required Brand Brand { get; init; }
        public required List<Comment> Comments { get; init; }
        public required List<ProductOrder> ProductOrders { get; init; }
        public required List<CartItem> CartItems { get; init; }

        public Product() { }

        public void UpdatePrice(decimal price)
        {
            FailIfLessThan(price, 0.01m, nameof(Price));
            _price = price;
        }

        public void RemoveComment(Comment comment)
        {
            var commentFound = Comments.FirstOrDefault(p => p.Id == comment.Id) ?? throw new InvalidOperationException("Comment Not Found !");
            Comments.Remove(comment);
        }

        private bool ValidateQuantity(int quantity)
        {
            return Quantity - Math.Abs(quantity) <= 0;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void AddQuantity(int quantity)
        {
            _quantity += Math.Abs(quantity);
        }

        public void RemoveQuantity(int quantity)
        {
            AssertionConcern.AssertStateFalse(ValidateQuantity(quantity), "The Quantity To Remove Is Greather Than Actual Quantity");

            _quantity -= Math.Abs(quantity);
        }

        public void ChangeDescription(string description)
        {
            FailIfNullOrEmpty(description, nameof(description));
            _description = description;
        }
    }
}
