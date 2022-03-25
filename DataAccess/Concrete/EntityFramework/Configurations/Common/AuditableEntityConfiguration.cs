using Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations.Common
{
    public static class AuditableEntityConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public static EntityTypeBuilder<TEntity> SetProperties(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.CreationDate)
                .IsRequired();
            return builder;
        }
    }
}
