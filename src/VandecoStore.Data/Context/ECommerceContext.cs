using Microsoft.EntityFrameworkCore;
using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartDb> Carts { get; set; }
        public DbSet<CartItemDb> CartItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<UserDb> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var model in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                model.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceContext).Assembly);

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
