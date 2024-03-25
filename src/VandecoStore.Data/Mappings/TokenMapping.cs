using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class TokenMapping : IEntityTypeConfiguration<TokenDb>
    {
        public void Configure(EntityTypeBuilder<TokenDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User).WithMany(p => p.Tokens);
            builder.Property(p => p.TokenCode).HasColumnType("varchar(30)");
        }
    }
}
