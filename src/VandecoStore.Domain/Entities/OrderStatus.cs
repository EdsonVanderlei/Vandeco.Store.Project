using VandecoStore.Core;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class OrderStatus : Entity
    {
        public Guid OrderId { get; set; }
        public string Notifier { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public StatusProcessEnum StatusProcessEnum { get; private set; }

        //EF RELATIONS
        public Order Order { get; private set; }

        protected OrderStatus() { }

        public OrderStatus(string notifier,Order order, StatusProcessEnum statusProcessEnum)
        {
            StatusProcessEnum = statusProcessEnum;
            Order = order;
            OrderId = order.Id;
            Notifier = notifier;   
            CreatedAt = DateTime.Now;
            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Notifier, "The Field Notifier Must Be Provided !");
        }
    }
}
