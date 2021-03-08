﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniEcommerce.DataAccess.EntityFramework;

namespace MiniEcommerce.DataAccess.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniEcommerce.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "HBV000017C1M6",
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 931, DateTimeKind.Local).AddTicks(6814),
                            Description = "Samsung Galaxy ailesinin yeni üyelerinden biri olan Samsung Galaxy S21 Ultra 5G 256 GB, özellikleriyle cezbediyor.",
                            Name = "Samsung Galaxy S21 Ultra 5G 256 GB",
                            Price = 14999m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Barcode = "HBV0000120X68",
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 932, DateTimeKind.Local).AddTicks(8290),
                            Description = "Yeni çift kamera sistemi. Tüm gün süren pil ömrü1. Bir akıllı telefondaki en dayanıklı cam. Ve Apple’ın bugüne kadarki en hızlı çipi.",
                            Name = "iPhone 11 64 GB",
                            Price = 7500m,
                            Stock = 60
                        },
                        new
                        {
                            Id = 3,
                            Barcode = "HBV00000TOMR2",
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 932, DateTimeKind.Local).AddTicks(8332),
                            Description = "10 (Q) versiyon Android işletim sistemiyle gelen telefonlar, kullanıcı dostu MIUI 11 arayüzü ile kolay kullanım konforuna sahiptir.",
                            Name = "Xiaomi Redmi Note 9 Pro 128 GB",
                            Price = 3399m,
                            Stock = 60
                        });
                });

            modelBuilder.Entity("MiniEcommerce.Entity.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6898),
                            ProductId = 1,
                            Url = "~/images/iphone.jpg"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6953),
                            ProductId = 2,
                            Url = "~/images/samsung.jpg"
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6956),
                            ProductId = 3,
                            Url = "~/images/xiaomi.jpg"
                        });
                });

            modelBuilder.Entity("MiniEcommerce.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MiniEcommerce.Entity.ProductImage", b =>
                {
                    b.HasOne("MiniEcommerce.Entity.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
