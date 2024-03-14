using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class ProductOrder : EntityValidation
    {
        private int _quantity;
        public required int Quantity 
        {
            get => _quantity;
            init
            {
                FailIfLessThan(value, 1, nameof(value));
                _quantity = 0;
            }
        }
        public required decimal Price { get; init; }
        public required Order Order { get; init; }
        public required Product Product { get; init; }

        public ProductOrder() { }
    }
}
