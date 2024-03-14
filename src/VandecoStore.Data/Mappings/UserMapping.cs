using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.DocumentNumber).HasColumnType("varchar(50)");
            builder.Property(p => p.MailAddress).HasColumnType("varchar(100)");
            builder.Property(p => p.Fax).HasColumnType("varchar(20)");
            builder.Property(p => p.Phone).HasColumnType("varchar(20)");
        }
    }
}
