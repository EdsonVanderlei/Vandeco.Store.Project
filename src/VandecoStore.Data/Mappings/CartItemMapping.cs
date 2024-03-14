using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class CartItemMapping : IEntityTypeConfiguration<CartItemDb>
    {
        public void Configure(EntityTypeBuilder<CartItemDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Product).WithMany(p => p.CartItems).HasForeignKey(p => p.ProductId);  
        }
    }
}
