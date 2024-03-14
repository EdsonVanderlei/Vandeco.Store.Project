using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Brand : EntityValidation
    {
        private string _name;
        public required string Name
        {
            get => _name;
            init
            {
                FailIfNullOrEmpty(value, nameof(Name));
                _name = value;
            }
        }
        private string _description;
        public required string Description
        {
            get => _description;
            init
            {
                FailIfNullOrEmpty(value, nameof(Description));
                _description = value;
            }
        }
        public List<Product> Products { get; init; } = [];

        public Brand() { }
    }
}
