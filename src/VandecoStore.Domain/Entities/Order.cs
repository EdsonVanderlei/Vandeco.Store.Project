using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Order : Entity
    {
        public Guid PaymentId { get; private set; }
        public decimal TotalPrice { get; private set; }

        //EF Relations
        public List<ProductOrder> ProductOrders { get; private set; } = [];
        public Address Address { get; private set; }
        public User User { get; private set; }
        public Payment Payment { get; private set; }

        public Order(Address address, User user, List<ProductOrder> productOrders, Payment payment)
        {
            ProductOrders = productOrders;
            Address = address;
            User = user;
            CalculateTotalPrice();
            Payment = payment;
            PaymentId = payment.Id;
        }

        protected Order() { }

        public void AddProductOrder(ProductOrder productOrder)
        {
            ProductOrders.Add(productOrder);
            CalculateTotalPrice();
        }

        public void RemoveProductOrder(ProductOrder productOrder)
        {
            var productOrderFound = ProductOrders.FirstOrDefault(p = p => p.Id == productOrder.Id) ?? throw new InvalidOperationException("ProductOrder Not Found !");
            ProductOrders.Remove(productOrderFound);
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = ProductOrders.Sum(p => p.Quantity * p.Price);
        }
    }
}
