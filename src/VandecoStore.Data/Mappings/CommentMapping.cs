using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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
