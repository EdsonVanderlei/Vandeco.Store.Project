using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class ReceiptPurchaseDb : Entity
    {
        public required Guid OrderGuid { get; init; }
        public required string Code { get; init; }
        public required bool Approved { get; init; }
        public required string ApprovedBy { get; init; }
        public required decimal Value { get; init; }
        public required string IssuerDocument { get; init; }
        //EF RELATIONS
        public required OrderDb Order { get; init; }

        public ReceiptPurchaseDb() { }

        public ReceiptPurchase ToReceiptPurchase()
        {
            return new ReceiptPurchase
            {
                Approved = Approved,
                ApprovedBy = ApprovedBy,
                Code = Code,
                Order = Order.ToOrder(),
                Value = Value,
                Id = Id,
            };
        }
    }
}
