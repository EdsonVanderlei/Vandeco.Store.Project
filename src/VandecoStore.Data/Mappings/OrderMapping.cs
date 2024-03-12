using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Address).WithMany(p => p.Orders).HasForeignKey(p => p.AddressId);
            builder.HasOne(p => p.User).WithMany(p => p.Orders).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Payment).WithOne(p => p.Order);
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,4)");
        }
    }
}
