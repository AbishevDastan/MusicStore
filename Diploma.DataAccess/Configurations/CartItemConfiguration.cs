using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class CartItemConfiguration
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ItemId });

            builder.Property(x => x.Quantity).IsRequired();

            builder.ToTable("CartItems");
        }
    }
}
