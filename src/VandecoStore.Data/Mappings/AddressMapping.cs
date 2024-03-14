using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<AddressDb>
    {
        public void Configure(EntityTypeBuilder<AddressDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Street).HasColumnType("varchar(150)").IsRequired();
            builder.Property(p => p.ZipCode).HasColumnType("varchar(9)").IsRequired();
            builder.Property(p => p.NeighboardHood).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.City).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.State).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Country).HasColumnType("varchar(90)").IsRequired();
            builder.Property(p => p.Number).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Complement).HasColumnType("varchar(100)").IsRequired();

            //Relations
            builder.HasOne(p => p.User).WithMany(p => p.Addresses).HasForeignKey(p => p.UserId);
        }
    }
}
