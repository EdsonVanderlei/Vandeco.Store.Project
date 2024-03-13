using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.OwnsOne(p => p.Document, pm =>
            {
                pm.Property(p => p.DocumentNumber).HasColumnType("varchar(20)").IsRequired();
            });
            builder.OwnsOne(p => p.Phone, pm =>
            {
                pm.Property(p => p.AreaCode).HasColumnType("int");
                pm.Property(p => p.CountryCode).HasColumnType("int");
                pm.Property(p => p.PhoneNumber).HasColumnType("varchar(30)").IsRequired();
            });
            builder.OwnsOne(p => p.Mail, pm =>
            {
                pm.Property(p => p.Address).HasColumnType("varchar(80)").IsRequired();
            });
            builder.OwnsOne(p => p.Fax, pm =>
            {
                pm.Property(p => p.AreaCode).HasColumnType("int");
                pm.Property(p => p.CountryCode).HasColumnType("int");
                pm.Property(p => p.PhoneNumber).HasColumnType("varchar(30)").IsRequired();
            });
        }
    }
}
