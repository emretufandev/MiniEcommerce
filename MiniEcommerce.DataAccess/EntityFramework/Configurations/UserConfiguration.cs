using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(50);
        }
    }
}
