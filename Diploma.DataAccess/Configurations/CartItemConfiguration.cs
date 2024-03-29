﻿using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configurations
{
    public class CartItemConfiguration
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(o => new { o.UserId, o.ItemId });

            builder.Property(x => x.Quantity);

            builder.ToTable("CartItems");
        }
    }
}
