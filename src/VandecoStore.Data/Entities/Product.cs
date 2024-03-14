using VandecoStore.Core;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Data.Entities
{
    public class Product : Entity
    {
        public Guid BrandId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public CategoryEnum Category { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }

        //EF relation
        public Brand Brand { get; private set; }
        public List<CommentDb> Comments { get; private set; } = [];
        public List<ProductOrder> ProductOrders { get; private set; } = [];
        public List<CartItemDb> CartItems { get; private set; }

        public Product(string name, decimal price, int quantity, CategoryEnum category, string description, Brand brand)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Description = description;
            Rate = 0;
            Brand = brand;
            BrandId = brand.Id;
            Validate();
        }

        protected Product() { }

        public void UpdatePrice(decimal price)
        {
            AssertionConcern.AssertArgumentRange(price, 0.01m, decimal.MaxValue, "The Field Price Must Be Greather Than 0 !");
            Price = price;
        }

        public void RemoveComment(CommentDb comment)
        {
           var commentFound = Comments.FirstOrDefault(p => p.Id == comment.Id) ?? throw new InvalidOperationException("Comment Not Found !");
           Comments.Remove(comment);
        }

        private bool ValidateQuantity(int quantity)
        {
            return Quantity - Math.Abs(quantity) <= 0;
        }

        public void AddComment(CommentDb comment)
        {
            Comments.Add(comment);
        }

        public void AddQuantity(int quantity)
        {
            Quantity += Math.Abs(quantity); 
        }

        public void RemoveQuantity(int quantity)
        {
            AssertionConcern.AssertStateFalse(ValidateQuantity(quantity), "The Quantity To Remove Is Greather Than Actual Quantity");

            Quantity -= Math.Abs(quantity);
        }

        public void ChangeDescription(string description)
        {
            AssertionConcern.AssertArgumentNotEmpty(description, "The Field Description Must Be Provided !");
            Description = description;
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "The Field Name Must Be Provided !");
            AssertionConcern.AssertArgumentNotEmpty(Description, "The Field Description Must Be Provided !");
            AssertionConcern.AssertArgumentRange(Price,0.01m,decimal.MaxValue, "The Field Price Must Be Greather Than 0 !");
        }
    }
}
