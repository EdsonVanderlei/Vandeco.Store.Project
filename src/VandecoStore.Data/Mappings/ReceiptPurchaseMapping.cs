using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class ReceiptPurchaseMapping : IEntityTypeConfiguration<ReceiptPurchaseDb>
    {
        public void Configure(EntityTypeBuilder<ReceiptPurchaseDb> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Code)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Value).HasColumnType("decimal(18,4)");
            builder.Property(p => p.ApprovedBy)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

            builder.Property(p => p.IssuerDocument).HasColumnType("varchar(20)");
        }
    }
}
