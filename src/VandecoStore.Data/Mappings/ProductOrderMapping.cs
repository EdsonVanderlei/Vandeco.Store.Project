using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class ProductOrderMapping : IEntityTypeConfiguration<ProductOrderDb>
    {
        public void Configure(EntityTypeBuilder<ProductOrderDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Price)
                    .HasColumnType("decimal(18,4)")
                    .IsRequired();
            builder.HasOne(p => p.Order)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(p => p.OrderId);
            builder.HasOne(p => p.Product)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(p => p.ProductId);
        }
    }
}
