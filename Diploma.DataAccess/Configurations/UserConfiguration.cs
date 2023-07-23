using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Email);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.Hash);
            builder.Property(x => x.Salt);
            builder.Property(x => x.Role);

            builder.ToTable("Users");
        }
    }
}
