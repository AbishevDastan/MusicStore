﻿// <auto-generated />
using System;
using Diploma.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230906130706_5")]
    partial class _5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Diploma.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ItemId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "images/Categories/acoustic-guitars-category.jpg",
                            Name = "Acoustic Guitars",
                            Url = "acoustic-guitars"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "images/Categories/electric-guitars-category.jpg",
                            Name = "Electric Guitars",
                            Url = "electric-guitars"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "images/Categories/bass-guitars-category.jpg",
                            Name = "Bass Guitars",
                            Url = "bass-guitars"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "images/Categories/drums-category.jpg",
                            Name = "Drums",
                            Url = "drums"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "images/Categories/trumpets-category.jpg",
                            Name = "Trumpets",
                            Url = "trumpets"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "images/Categories/violins-category.jpg",
                            Name = "Violins",
                            Url = "violins"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "images/Categories/pianos-category.jpg",
                            Name = "Pianos",
                            Url = "pianos"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "images/Categories/synthesizers-category.jpg",
                            Name = "Synthesizers",
                            Url = "synthesizers"
                        });
                });

            modelBuilder.Entity("Diploma.Domain.Entities.DeliveryInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryInformations", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<int>("SoldQuantity")
                        .HasColumnType("int");

                    b.Property<int>("StockStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam id sodales nunc. Duis ut sapien tincidunt, tempor felis in, imperdiet diam. Vivamus eu justo sit amet nibh feugiat congue. ",
                            ImageUrl = "images/Items/acoustic-guitar-1.jpg",
                            Name = "Martin 000-28",
                            Price = 3500m,
                            QuantityInStock = 10,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Nam tempor, diam quis porta sagittis, dolor erat auctor nisi, eu pulvinar lacus massa in velit. Nam et aliquet felis.",
                            ImageUrl = "images/Items/acoustic-guitar-2.jpg",
                            Name = "Ibanez AW54OPN",
                            Price = 399m,
                            QuantityInStock = 20,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Nullam auctor vitae velit a iaculis. Proin sed urna sit amet ante tincidunt imperdiet. Curabitur ac condimentum elit.",
                            ImageUrl = "images/Items/acoustic-guitar-3.jpg",
                            Name = "Ibanez Talman TCY10E",
                            Price = 1999m,
                            QuantityInStock = 17,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Nam ac diam lacinia, porta velit et, venenatis quam. In a quam sit amet est aliquet convallis nec vel ligula.",
                            ImageUrl = "images/Items/electric-guitar-1.jpg",
                            Name = "Jackson JS32",
                            Price = 1499m,
                            QuantityInStock = 20,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Sed dapibus tristique lacinia. Cras laoreet dictum elit id rutrum.",
                            ImageUrl = "images/Items/electric-guitar-2.jpg",
                            Name = "Jackson JS22",
                            Price = 1m,
                            QuantityInStock = 10,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Nullam rutrum velit nulla, a mattis quam consequat eu. Nunc sagittis quam eget orci faucibus mattis.",
                            ImageUrl = "images/Items/bass-guitar-1.jpg",
                            Name = "Jackson Bass JS2",
                            Price = 999m,
                            QuantityInStock = 23,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Nulla vulputate viverra nisl in tincidunt. Mauris id tincidunt libero, a venenatis mauris. Morbi aliquam hendrerit sem id elementum.",
                            ImageUrl = "images/Items/bass-guitar-2.jpg",
                            Name = "Ibanez SR",
                            Price = 1799m,
                            QuantityInStock = 7,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Description = "Mauris vitae maximus ante. Nunc vitae lorem eros. Duis vulputate pharetra eros at tincidunt.",
                            ImageUrl = "images/Items/drums-1.jpg",
                            Name = "Donner DED-100",
                            Price = 399m,
                            QuantityInStock = 15,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Description = "Quisque bibendum lacinia ante, rhoncus facilisis enim facilisis sit amet. Vivamus condimentum nunc nec maximus porttitor.",
                            ImageUrl = "images/Items/drums-2.jpg",
                            Name = "Vangoa Drum Kit",
                            Price = 899m,
                            QuantityInStock = 6,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            Description = "Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam lacinia accumsan urna, vel cursus nisl maximus pellentesque.",
                            ImageUrl = "images/Items/trumpet-1.jpg",
                            Name = "Glory Bb Trumpet",
                            Price = 128m,
                            QuantityInStock = 12,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 6,
                            Description = "Mauris eget sodales dolor. Maecenas rutrum ultricies mauris et finibus.",
                            ImageUrl = "images/Items/violin-1.jpg",
                            Name = "Poseidon Violin",
                            Price = 99m,
                            QuantityInStock = 15,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 6,
                            Description = "Nullam ac arcu a metus maximus aliquet eget vel dolor. Nulla ac volutpat mauris, quis pulvinar nulla.",
                            ImageUrl = "images/Items/violin-2.jpg",
                            Name = "Cecilio MV500+92D",
                            Price = 249m,
                            QuantityInStock = 6,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 7,
                            Description = "Vestibulum accumsan lorem erat, sit amet congue ligula facilisis eget. Mauris mattis eget velit vitae molestie.",
                            ImageUrl = "images/Items/piano-1.jpg",
                            Name = "Cossain Digital Piano",
                            Price = 599m,
                            QuantityInStock = 8,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 7,
                            Description = "Nullam convallis tempor gravida. Suspendisse non est vitae tellus pretium fringilla et at eros. Nam venenatis elit quis faucibus porta.",
                            ImageUrl = "images/Items/piano-2.jpg",
                            Name = "FingerBallet Piano",
                            Price = 399m,
                            QuantityInStock = 10,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 7,
                            Description = "Aenean id blandit libero. Curabitur nec enim aliquet, placerat arcu et, pellentesque est. Fusce condimentum tincidunt nulla, sit amet hendrerit diam mollis fringilla.",
                            ImageUrl = "images/Items/piano-3.jpg",
                            Name = "Magicon BX2 Piano",
                            Price = 720m,
                            QuantityInStock = 10,
                            SoldQuantity = 0,
                            StockStatus = 0
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 8,
                            Description = "Praesent viverra ipsum id sem hendrerit sagittis. Praesent molestie faucibus elementum.",
                            ImageUrl = "images/Items/synthesizer-1.jpg",
                            Name = "Behringer DeepMind 6",
                            Price = 499m,
                            QuantityInStock = 4,
                            SoldQuantity = 0,
                            StockStatus = 0
                        });
                });

            modelBuilder.Entity("Diploma.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeliveryInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.WishlistItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WishlistItems", (string)null);
                });

            modelBuilder.Entity("Diploma.Domain.Entities.Item", b =>
                {
                    b.HasOne("Diploma.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Diploma.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Diploma.Domain.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Diploma.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
