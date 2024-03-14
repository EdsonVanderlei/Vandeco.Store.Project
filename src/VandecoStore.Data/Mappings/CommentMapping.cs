using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Data.Entities;

namespace VandecoStore.Data.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<CommentDb>
    {
        public void Configure(EntityTypeBuilder<CommentDb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title)
                   .HasColumnType("varchar(80)")
                   .IsRequired();
            builder.Property(p => p.Text)
                   .HasColumnType("varchar(120)")
                   .IsRequired();
            builder.HasOne(p => p.Product).WithMany(p => p.Comments).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.User).WithMany(p => p.Comments).HasForeignKey(p => p.UserId);
        }
    }
}
