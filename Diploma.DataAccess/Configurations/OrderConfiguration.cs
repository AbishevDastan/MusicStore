using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.OrderDate);
            builder.Property(x => x.UserId);

            builder.HasMany(x => x.OrderItems);

            builder.ToTable("Orders");
        }
    }
}
