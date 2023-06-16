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

            modelBuilder.Entity<Item>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ItemId});

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Guitar1",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest1",
                    CategoryId = 1,
                    Featured = true,
                    Price = 75
                },

                new Item
                {
                    Id = 2,
                    Name = "Guitar2",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest2",
                    CategoryId = 1,
                    Price = 55
                },

                new Item
                {
                    Id = 3,
                    Name = "Drums1",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest3",
                    CategoryId = 2,
                    Featured = true,
                    Price = 45
                },

                new Item
                {
                    Id = 4,
                    Name = "Drums2",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest4",
                    CategoryId = 2,
                    Price = 65
                });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Guitars",
                    Url = "guitars"

                },
                
                new Category
                {
                    Id = 2,
                    Name = "Percussion",
                    Url = "percussion"
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
