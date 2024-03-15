using VandecoStore.Domain.Enum;

namespace VandecoStore.Domain.Entities
{
    public class Order : EntityValidation
    {
        //EF Relations
        public required List<ProductOrder> ProductOrders { get; init; }
        private Address _address;
        public required Address Address
        {
            get => _address;
            init
            {
                _address = value;
            }
        }
        public bool IsDelivered { get; private set; } = false;
        public required List<OrderStatus> OrdersStatus { get; init; } = [];
        public User User { get; }
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
            if (statusProcessEnum.Equals(StatusProcessEnum.Delivered))
                IsDelivered = true;
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
