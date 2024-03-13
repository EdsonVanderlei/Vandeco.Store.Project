using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Mappings
{
    public class OrderStatusMapping : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Notifier).HasColumnType("varchar(100)").IsRequired();
            builder.HasOne(p => p.Order).WithMany(p => p.OrdersStatus).HasForeignKey(p => p.OrderId);
        }
    }
}
