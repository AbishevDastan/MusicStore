using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class CartItemConfiguration
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => new {x.ItemId, x.UserId});
            builder.Property(x => x.Quantity);

            builder.ToTable("CartItems");
        }
    }
}
