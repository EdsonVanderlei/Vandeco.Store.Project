using System.Collections.ObjectModel;
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
                FailIfNullOrEmpty(value, nameof(Name));
                _name = value;
            }
        }
        private bool _active = true;
        public bool Active { get => _active; }
        private decimal _price;
        public required decimal Price
        {
            get => _price;
            init
            {
                FailIfLessThan(value, 0.01m, nameof(Price));
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
        public required string Description
        {
            get => _description;
            init
            {
                FailIfNullOrEmpty(value, nameof(Description));
                _description = value;
            }
        }
        public required Brand Brand { get; init; }
        private List<Comment> _comments = [];
        public ReadOnlyCollection<Comment> Comments { get => _comments.AsReadOnly(); }
        public List<ProductOrder> ProductOrders { get; }
        public List<CartItem> CartItems { get; }

        public Product() { }

        public void UpdatePrice(decimal price)
        {
            FailIfLessThan(price, 0.01m, nameof(Price));
            _price = price;
        }

        public void RemoveComment(Comment comment)
        {
            var commentFound = Comments.FirstOrDefault(p => p.Id == comment.Id) ?? throw new DomainException("Comment Not Found !");
            _comments.Remove(comment);
        }

        private bool ValidateQuantity(int quantity)
        {
            return Quantity <= Math.Abs(quantity);
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public void AddQuantity(int quantity)
        {
            _quantity += Math.Abs(quantity);
        }

        public void ActivateProduct()
        {
            _active = true;
        }

        public void DesactivateProduct()
        {
            _active = false;
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
