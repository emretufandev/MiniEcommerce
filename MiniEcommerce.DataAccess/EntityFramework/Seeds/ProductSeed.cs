using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Barcode = "HBV000017C1M6",
                    Name = "Samsung Galaxy S21 Ultra 5G 256 GB",
                    Price = 14999,
                    Description = "Samsung Galaxy ailesinin yeni üyelerinden biri olan Samsung Galaxy S21 Ultra 5G 256 GB, özellikleriyle cezbediyor.",
                    CreatedTime = DateTime.Now,
                    Stock = 50
                },
                new Product
                {
                    Id = 2,
                    Barcode = "HBV0000120X68",
                    Name = "iPhone 11 64 GB",
                    Price = 7500,
                    Description = "Yeni çift kamera sistemi. Tüm gün süren pil ömrü1. Bir akıllı telefondaki en dayanıklı cam. Ve Apple’ın bugüne kadarki en hızlı çipi.",
                    CreatedTime = DateTime.Now,
                    Stock = 60
                },
                new Product
                {
                    Id = 3,
                    Barcode = "HBV00000TOMR2",
                    Name = "Xiaomi Redmi Note 9 Pro 128 GB",
                    Price = 3399,
                    Description = "10 (Q) versiyon Android işletim sistemiyle gelen telefonlar, kullanıcı dostu MIUI 11 arayüzü ile kolay kullanım konforuna sahiptir.",
                    CreatedTime = DateTime.Now,
                    Stock = 60
                }
                );
        }
    }
}
