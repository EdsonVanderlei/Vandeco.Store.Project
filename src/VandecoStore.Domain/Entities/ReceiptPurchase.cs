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
                FailIfNullOrEmpty(value, nameof(Code));
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
                FailIfNullOrEmpty(value, nameof(ApprovedBy));
                _approvedBy = value;
            }
        }
        private decimal _value;
        public required decimal Value 
        {
            get => _value;
            init
            {
                FailIfLessThan(value, 0.01m, nameof(Value));
                _value = value;
            }
        }
        public Document IssuerDocument { get; private set; }
        public required Order Order { get; init; }

        public ReceiptPurchase() { }

    }
}
