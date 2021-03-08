using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Barcode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
        }
    }
}
