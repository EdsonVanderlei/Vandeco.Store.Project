using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Mappings
{
    public class ProductOrderMapping : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
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
