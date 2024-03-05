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

        public ProductOrder(int quantity, decimal price, Order order, Product product)
        {
            ProductId = product.Id;
            OrderId = Order.Id;
            Quantity = quantity;
            Price = price;
            Order = order;
            Product = product;
        }
        protected ProductOrder() { }
    }
}
