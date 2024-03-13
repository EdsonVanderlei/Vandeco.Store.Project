using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Tests.Tests.Entities;

namespace VandecoStore.Data.Mappings
{
    public class ReceiptPurchaseMapping : IEntityTypeConfiguration<ReceiptPurchase>
    {
        public void Configure(EntityTypeBuilder<ReceiptPurchase> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Code)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Value).HasColumnType("decimal(18,4)");
            builder.Property(p => p.ApprovedBy)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

            builder.OwnsOne(p => p.IssuerDocument, pm =>
            {
                pm.Property(p => p.DocumentNumber).HasColumnType("varchar(20)").IsRequired();
            });
        }
    }
}
