using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class CartMapping : IEntityTypeConfiguration<CartDb>
    {
        public void Configure(EntityTypeBuilder<CartDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User).WithOne(p => p.Cart);
        }
    }
}
