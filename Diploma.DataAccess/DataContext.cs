using Diploma.DataAccess.Configurations;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new OrderItemConfiguration().Configure(modelBuilder.Entity<OrderItem>());
            new CartItemConfiguration().Configure(modelBuilder.Entity<CartItem>());
            new WishlistItemConfiguration().Configure(modelBuilder.Entity<WishlistItem>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
