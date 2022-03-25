﻿using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(t => t.Name);
            builder.Property(t => t.Surname);
            builder.Property(t => t.Username);
            builder.Property(t => t.HashPassword);
            builder.Property(t => t.SaltPassword);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);
            builder.HasData(new User { Id=1, Name = "thos", SaltPassword = passwordSalt, HashPassword = passwordHash });
        }
    }
}
