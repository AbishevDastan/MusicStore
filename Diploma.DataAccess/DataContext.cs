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
            new DeliveryInformationConfiguration().Configure(modelBuilder.Entity<DeliveryInformation>());

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Acoustic Guitars", Url = "acoustic-guitars", ImageUrl = "images/Categories/acoustic-guitars-category.jpg" },
            new Category { Id = 2, Name = "Electric Guitars", Url = "electric-guitars", ImageUrl = "images/Categories/electric-guitars-category.jpg" },
            new Category { Id = 3, Name = "Bass Guitars", Url = "bass-guitars", ImageUrl = "images/Categories/bass-guitars-category.jpg" },
            new Category { Id = 4, Name = "Drums", Url = "drums", ImageUrl = "images/Categories/drums-category.jpg" },
            new Category { Id = 5, Name = "Trumpets", Url = "trumpets", ImageUrl = "images/Categories/trumpets-category.jpg" },
            new Category { Id = 6, Name = "Violins", Url = "violins", ImageUrl = "images/Categories/violins-category.jpg" },
            new Category { Id = 7, Name = "Pianos", Url = "pianos", ImageUrl = "images/Categories/pianos-category.jpg" },
            new Category { Id = 8, Name = "Synthesizers", Url = "synthesizers", ImageUrl = "images/Categories/synthesizers-category.jpg" }
            );

            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Martin 000-28", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam id sodales nunc. Duis ut sapien tincidunt, tempor felis in, imperdiet diam. Vivamus eu justo sit amet nibh feugiat congue. ", ImageUrl = "images/Items/acoustic-guitar-1.jpg", Price = 3500, QuantityInStock = 10, CategoryId = 1 },
            new Item { Id = 2, Name = "Ibanez AW54OPN", Description = "Nam tempor, diam quis porta sagittis, dolor erat auctor nisi, eu pulvinar lacus massa in velit. Nam et aliquet felis.", ImageUrl = "images/Items/acoustic-guitar-2.jpg", Price = 399, QuantityInStock = 20, CategoryId = 1 },
            new Item { Id = 3, Name = "Ibanez Talman TCY10E", Description = "Nullam auctor vitae velit a iaculis. Proin sed urna sit amet ante tincidunt imperdiet. Curabitur ac condimentum elit.", ImageUrl = "images/Items/acoustic-guitar-3.jpg", Price = 1999, QuantityInStock = 17, CategoryId = 1 },
            new Item { Id = 4, Name = "Jackson JS32", Description = "Nam ac diam lacinia, porta velit et, venenatis quam. In a quam sit amet est aliquet convallis nec vel ligula.", ImageUrl = "images/Items/electric-guitar-1.jpg", Price = 1499, QuantityInStock = 20, CategoryId = 2 },
            new Item { Id = 5, Name = "Jackson JS22", Description = "Sed dapibus tristique lacinia. Cras laoreet dictum elit id rutrum.", ImageUrl = "images/Items/electric-guitar-2.jpg", Price = 1, QuantityInStock = 10, CategoryId = 2 },
            new Item { Id = 6, Name = "Jackson Bass JS2", Description = "Nullam rutrum velit nulla, a mattis quam consequat eu. Nunc sagittis quam eget orci faucibus mattis.", ImageUrl = "images/Items/bass-guitar-1.jpg", Price = 999, QuantityInStock = 23, CategoryId = 3 },
            new Item { Id = 7, Name = "Ibanez SR", Description = "Nulla vulputate viverra nisl in tincidunt. Mauris id tincidunt libero, a venenatis mauris. Morbi aliquam hendrerit sem id elementum.", ImageUrl = "images/Items/bass-guitar-2.jpg", Price = 1799, QuantityInStock = 7, CategoryId = 3 },
            new Item { Id = 8, Name = "Donner DED-100", Description = "Mauris vitae maximus ante. Nunc vitae lorem eros. Duis vulputate pharetra eros at tincidunt.", ImageUrl = "images/Items/drums-1.jpg", Price = 399, QuantityInStock = 15, CategoryId = 4 },
            new Item { Id = 9, Name = "Vangoa Drum Kit", Description = "Quisque bibendum lacinia ante, rhoncus facilisis enim facilisis sit amet. Vivamus condimentum nunc nec maximus porttitor.", ImageUrl = "images/Items/drums-2.jpg", Price = 899, QuantityInStock = 6, CategoryId = 4 },
            new Item { Id = 10, Name = "Glory Bb Trumpet", Description = "Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam lacinia accumsan urna, vel cursus nisl maximus pellentesque.", ImageUrl = "images/Items/trumpet-1.jpg", Price = 128, QuantityInStock = 12, CategoryId = 5 },
            new Item { Id = 11, Name = "Poseidon Violin", Description = "Mauris eget sodales dolor. Maecenas rutrum ultricies mauris et finibus.", ImageUrl = "images/Items/violin-1.jpg", Price = 99, QuantityInStock = 15, CategoryId = 6 },
            new Item { Id = 12, Name = "Cecilio MV500+92D", Description = "Nullam ac arcu a metus maximus aliquet eget vel dolor. Nulla ac volutpat mauris, quis pulvinar nulla.", ImageUrl = "images/Items/violin-2.jpg", Price = 249, QuantityInStock = 6, CategoryId = 6 },
            new Item { Id = 13, Name = "Cossain Digital Piano", Description = "Vestibulum accumsan lorem erat, sit amet congue ligula facilisis eget. Mauris mattis eget velit vitae molestie.", ImageUrl = "images/Items/piano-1.jpg", Price = 599, QuantityInStock = 8, CategoryId = 7 },
            new Item { Id = 14, Name = "FingerBallet Piano", Description = "Nullam convallis tempor gravida. Suspendisse non est vitae tellus pretium fringilla et at eros. Nam venenatis elit quis faucibus porta.", ImageUrl = "images/Items/piano-2.jpg", Price = 399, QuantityInStock = 10, CategoryId = 7 },
            new Item { Id = 15, Name = "Magicon BX2 Piano", Description = "Aenean id blandit libero. Curabitur nec enim aliquet, placerat arcu et, pellentesque est. Fusce condimentum tincidunt nulla, sit amet hendrerit diam mollis fringilla.", ImageUrl = "images/Items/piano-3.jpg", Price = 720, QuantityInStock = 10, CategoryId = 7 },
            new Item { Id = 16, Name = "Behringer DeepMind 6", Description = "Praesent viverra ipsum id sem hendrerit sagittis. Praesent molestie faucibus elementum.", ImageUrl = "images/Items/synthesizer-1.jpg", Price = 499, QuantityInStock = 4, CategoryId = 8 }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryInformation> DeliveryInformations { get; set; }
    }
}
