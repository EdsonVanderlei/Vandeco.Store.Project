using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Order : Entity
    {
        public Guid AddressId {  get; private set; }
        public Guid PaymentId { get; private set; }
        public Guid UserId { get; private set; }
        public decimal TotalPrice { get; private set; }

        //EF Relations
        public List<ProductOrder> ProductOrders { get; private set; } = [];
        public Address Address { get; private set; }
        public User User { get; private set; }
        public Payment Payment { get; private set; }

        public Order(User user, List<ProductOrder> productOrders, Payment payment, Address address)
        {
            ProductOrders.AddRange(productOrders);
            User = user;
            Address = address;
            AddressId = address.Id;
            Payment = payment;
            PaymentId = payment.Id;
            CalculateTotalPrice();
        }

        protected Order() { }

        public void AddProductOrder(ProductOrder productOrder)
        {
            ProductOrders.Add(productOrder);
            CalculateTotalPrice();
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }

        public void RemoveProductOrder(ProductOrder productOrder)
        {
            var productOrderFound = ProductOrders.FirstOrDefault(p => p.Equals(productOrder)) ?? throw new InvalidOperationException("ProductOrder Not Found !");
            ProductOrders.Remove(productOrderFound);
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = ProductOrders.Sum(p => p.Quantity * p.Price);
        }
    }
}
