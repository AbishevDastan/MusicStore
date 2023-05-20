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

            //modelBuilder.Entity<Item>()
            //    .Property(p => p.Price)
            //    .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemVariant>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemVariant>()
                .Property(p => p.InitialPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemVariant>()
                .HasKey(v => new { v.ItemId, v.ItemTypeId });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Guitar",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest1",
                    CategoryId = 1
                },

                new Item
                {
                    Id = 2,
                    Name = "Drums",
                    Image = "https://images.unsplash.com/photo-1638718619061-54b56803f459?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGpwZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=1000&q=60",
                    Description = "TestTestTestTest2",
                    CategoryId = 2
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

            modelBuilder.Entity<ItemType>().HasData(
                new ItemType
                {
                    Id = 1,
                    Name = "Black"
                },
                     
                new ItemType
                {
                    Id = 2,
                    Name = "White"
                },
            
                new ItemType
                {
                    Id = 3,
                    Name = "Red"
                },
                     
                new ItemType
                {
                    Id = 4,
                    Name = "Gray"
                });

            modelBuilder.Entity<ItemVariant>().HasData(
                new ItemVariant
                {
                    ItemId = 1,
                    ItemTypeId = 1,
                    Price = 100,
                    InitialPrice = 170
                },

                new ItemVariant
                {
                    ItemId = 1,
                    ItemTypeId = 2,
                    Price = 100,
                    InitialPrice = 170
                },
                new ItemVariant
                {
                    ItemId = 1,
                    ItemTypeId = 3,
                    Price = 100,
                    InitialPrice = 170
                },
                new ItemVariant
                {
                    ItemId = 1,
                    ItemTypeId = 4,
                    Price = 100,
                    InitialPrice = 170
                },

                new ItemVariant
                {
                    ItemId = 2,
                    ItemTypeId = 1,
                    Price = 100,
                    InitialPrice = 170
                },

                new ItemVariant
                {
                    ItemId = 2,
                    ItemTypeId = 2,
                    Price = 100,
                    InitialPrice = 170
                },
                new ItemVariant
                {
                    ItemId = 2,
                    ItemTypeId = 3,
                    Price = 100,
                    InitialPrice = 170
                },
                new ItemVariant
                {
                    ItemId = 2,
                    ItemTypeId = 4,
                    Price = 100,
                    InitialPrice = 170
                });

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemVariant> ItemVariants { get; set; }
    }
}
