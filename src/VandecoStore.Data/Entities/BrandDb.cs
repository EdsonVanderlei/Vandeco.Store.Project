using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class BrandDb : Entity
    {
        public required string Name { get; init; }
        public required string Description { get; init; }

        //EF Relation 
        public required List<ProductDb> Products { get; init; }

        public BrandDb() { }

        public Brand ToBrand()
        {
            return new Brand
            {
                Description = Description,
                Name = Name,
                Id = Id,
                Products = Products.Select(p => p.ToProduct()).ToList()
            };
        }
    }
}
