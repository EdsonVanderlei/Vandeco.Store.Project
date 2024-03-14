using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<ProductDb>
    {
        public void Configure(EntityTypeBuilder<ProductDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                    .HasColumnType("varchar(130)")
                    .IsRequired();
            builder.Property(p => p.Description)
                  .HasColumnType("varchar(200)")
                  .IsRequired();
            builder.Property(p => p.Price)
                    .HasColumnType("decimal(18,4)")
                    .IsRequired();
            builder.HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(b => b.BrandId);
        }
    }
}
