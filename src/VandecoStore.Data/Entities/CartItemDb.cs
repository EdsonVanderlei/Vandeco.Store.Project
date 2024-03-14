using VandecoStore.Core;

namespace VandecoStore.Data.Entities
{
    public class CartItemDb : Entity
    {
        public required Guid ProductId { get; init; }
        public required int Quantity { get; init; }

        // EF RELATIONS
        public required Product Product { get; init; }

        public CartItemDb() { }

        public CartItemDb ToCartItem()
        {
          
        }
    }
}
