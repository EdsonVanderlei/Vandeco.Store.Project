using VandecoStore.Core;

namespace VandecoStore.Data.Entities
{
    public class CartDb : EntityValidation
    {
        public required Guid UserId { get;  init; }
        public required UserDb User { get; init; }
        public required List<CartItemDb> CartItems { get; init; };

        public CartDb() { }
    }
}
