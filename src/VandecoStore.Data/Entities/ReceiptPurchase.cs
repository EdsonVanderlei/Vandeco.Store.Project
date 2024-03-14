using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class ReceiptPurchase : Entity
    {
        public Guid OrderGuid { get; private set; }
        public string Code { get; private set; }
        public bool Approved { get; private set; }
        public string ApprovedBy { get; private set; }
        public decimal Value { get; private set; }
        public Document IssuerDocument { get; private set; }

        //EF RELATIONS
        public Order Order { get; private set; }
        protected ReceiptPurchase() { }

        public ReceiptPurchase(string code, bool approved, string approvedBy, decimal value, Document document, Order order)
        {
            OrderGuid = order.Id;
            Order = order;
            Code = code;
            Approved = approved;
            ApprovedBy = approvedBy;
            Value = value;
            IssuerDocument = document;
            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Code, "The Field Code Must Be Provided !");
            AssertionConcern.AssertArgumentNotEmpty(ApprovedBy, "The Field ApprovedBy Must Be Provided !");
            AssertionConcern.AssertArgumentRange(Value, 0.1m, decimal.MaxValue, "The Field Value Must Be Greather Than 0 !");

        }
    }
}
