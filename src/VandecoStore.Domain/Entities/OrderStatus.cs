using VandecoStore.Core;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Domain.Entities
{
    public class OrderStatus : EntityValidation
    {
        private string _notifier;
        public required string Notifier
        {
            get => _notifier;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _notifier = value;
            }
        }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public required StatusProcessEnum StatusProcessEnum { get; init; }
        public required Order Order { get; init; }

        public OrderStatus() { }
    }
}
