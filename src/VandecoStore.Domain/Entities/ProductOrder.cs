using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class ProductOrder : Entity
    {
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        //EF Relations 
        public Order Order { get; private set; }
        public Product Product { get; private set; }

        public ProductOrder(Order order, Product product, int quantity)
        {
            ProductId = product.Id;
            OrderId = order.Id;
            Quantity = quantity;
            Price = product.Price;
            Order = order;
            Product = product;
            Validate();
        }

        protected ProductOrder() { }

        private void Validate()
        {
            AssertionConcern.AssertArgumentRange(Quantity, 1, int.MaxValue,"Quantity Must Be Greather Than 0");
        }

    }
}
