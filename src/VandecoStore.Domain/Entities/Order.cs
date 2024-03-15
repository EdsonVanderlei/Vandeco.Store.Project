using VandecoStore.Core;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Domain.Entities
{
    public class Order : EntityValidation
    {
        //EF Relations
        public required List<ProductOrder> ProductOrders { get; init; }
        private Address _address;
        public required Address Address {
            get => _address; 
            init
            {
                _address = value;
            }
        }
        public required List<OrderStatus> OrdersStatus { get; init; } = [];
        public required User User { get; init; }
        public required Payment Payment { get; init; }

        public Order() { }

        public void AddProductOrder(ProductOrder productOrder)
        {
            ProductOrders.Add(productOrder);
            CalculateTotalPrice();
        }

        public void UpdateOrderStatus(string notifier, StatusProcessEnum statusProcessEnum)
        {
            OrdersStatus.Add(new OrderStatus
            {
                Notifier = notifier,
                Order = this,
                StatusProcessEnum = statusProcessEnum,
            });
        }

        public void ChangeAddress(Address address)
        {
            _address = address;
        }

        public void RemoveProductOrder(ProductOrder productOrder)
        {
            var productOrderFound = ProductOrders.FirstOrDefault(p => p.Equals(productOrder)) ?? throw new InvalidOperationException("ProductOrder Not Found !");
            ProductOrders.Remove(productOrderFound);
            CalculateTotalPrice();
        }

        private decimal CalculateTotalPrice()
        {
            return ProductOrders.Sum(p => p.Quantity * p.Price);
        }
    }
}
