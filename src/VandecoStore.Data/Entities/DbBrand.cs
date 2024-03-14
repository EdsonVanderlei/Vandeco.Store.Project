using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class DbBrand : EntityValidation
    {
        public required string Name { get; init; }
        public required string Description { get; init; }

        //EF Relation 
        public required List<Product> Products { get; init; }

        public DbBrand() { }

        public Brand ToBrand() { }
    }
}
