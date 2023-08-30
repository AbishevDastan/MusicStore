using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class DeliveryInformationConfiguration
    {
        public void Configure(EntityTypeBuilder<DeliveryInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.UserId);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Street);
            builder.Property(x => x.City);
            builder.Property(x => x.State);
            builder.Property(x => x.Country);
            builder.Property(x => x.ZipCode);

            builder.ToTable("DeliveryInformations");
        }
    }
}
