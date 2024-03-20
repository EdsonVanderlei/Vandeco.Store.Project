

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class ReceiptPurchaseExtension
    {
        public static ReceiptPurchaseDb ToReceiptPurchase(this ReceiptPurchase receiptPurchase)
        {
            return new ReceiptPurchaseDb
            {
                Approved = receiptPurchase.Approved,
                ApprovedBy = receiptPurchase.ApprovedBy,
                Code = receiptPurchase.Code,
                IssuerDocument = receiptPurchase.IssuerDocument,
                Order = receiptPurchase.Order.ToOrderDb(),
                OrderGuid = receiptPurchase.Order.Id,
                Value = receiptPurchase.Value,
                Id = receiptPurchase.Id
            };
        }
    }
}
