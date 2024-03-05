using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Product : Entity
    {
        public Guid BrandId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }

        //EF relation
        public Brand Brand { get; private set; }
        public List<Comment> Comments { get; private set; }
        public List<ProductOrder> ProductOrders { get; private set; }   

        public Product(string name, decimal price, int quantity, Category category, string description, Brand brand)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Description = description;
            Rate = 0;
            Brand = brand;
            Comments = [];
            BrandId = brand.Id;
            Validate();
        }

        protected Product() { }

        public void UpdatePrice(decimal price)
        {
            AssertionConcern.AssertArgumentTrue(price > 0, "The Field Price Must be greather than 0 !");
            Price = price;
        }

        public void RemoveComment(Comment comment)
        {
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
            Quantity += Math.Abs(quantity); 
        }

        public void RemoveQuantity(int quantity)
        {
            AssertionConcern.AssertArgumentTrue(ValidateQuantity(quantity), "The quantity to remove is greather than actual quantity");

            Quantity -= Math.Abs(quantity);
        }

        public void ChangeDescription(string description)
        {
            AssertionConcern.AssertArgumentNotEmpty(description, "The Field Description Must be Provided !");
            Description = description;
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "The Field Name Must be Provided !");
            AssertionConcern.AssertArgumentNotEmpty(Description, "The Field Name Must be Provided !");
            AssertionConcern.AssertArgumentTrue(Price > 0, "The Field Price Must be greather than 0 !");
        }
    }
}
