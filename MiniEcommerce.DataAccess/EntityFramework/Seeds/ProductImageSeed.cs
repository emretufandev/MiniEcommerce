using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Seeds
{
    public class ProductImageSeed : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(
                new ProductImage
                {
                    Id = 1,
                    ProductId = 1,
                    Url = "~/images/iphone.jpg",
                    CreatedTime = DateTime.Now
                },
                new ProductImage
                {
                    Id = 2,
                    ProductId = 2,
                    Url = "~/images/samsung.jpg",
                    CreatedTime = DateTime.Now
                },
                new ProductImage
                {
                    Id = 3,
                    ProductId = 3,
                    Url = "~/images/xiaomi.jpg",
                    CreatedTime = DateTime.Now
                });
        }
    }
}
