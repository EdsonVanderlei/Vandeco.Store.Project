using VandecoStore.Core;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.Entities
{
    public class ReceiptPurchase : EntityValidation
    {
        private string _code;
        public required string Code 
        {
            get => _code;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _code = value;
            }
        }
        public required bool Approved { get; init; }
        private string _approvedBy;
        public required string ApprovedBy
        {
            get => _approvedBy;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
            }
        }
        private decimal _value;
        public required decimal Value 
        {
            get => _value;
            init
            {
                FailIfLessThan(value, 0.01m, nameof(value));
            }
        }
        public Document IssuerDocument { get; private set; }
        public required Order Order { get; init; }

        public ReceiptPurchase() { }

    }
}
