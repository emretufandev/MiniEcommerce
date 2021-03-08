using Microsoft.EntityFrameworkCore;
using MiniEcommerce.DataAccess.EntityFramework.Configurations;
using MiniEcommerce.DataAccess.EntityFramework.Seeds;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PODSKTE-PC;Initial Catalog=MiniEcommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed());
            modelBuilder.ApplyConfiguration(new ProductImageSeed());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
