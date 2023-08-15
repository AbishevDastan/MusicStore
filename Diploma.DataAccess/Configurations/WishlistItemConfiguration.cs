using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class WishlistItemConfiguration
    {
          public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.ItemId);
            builder.Property(x => x.UserId);

            builder.ToTable("WishlistItems");
        }
    }
}
