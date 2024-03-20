

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class BrandExtension
    {
        public static BrandDb ToBrandDb(this Brand brand)
        {
            return new BrandDb
            {
                Description = brand.Description,
                Name = brand.Name,
                Products = brand.Products.Select(p => p.ToProductDb()).ToList(),
                Id = brand.Id
            };
        }
    }
}
