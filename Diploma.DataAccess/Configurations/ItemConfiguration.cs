using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.QuantityInStock);
            builder.Property(x => x.SoldQuantity);
            builder.Property(x => x.StockStatus);
            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.ToTable("Items");
        }
    }
}
