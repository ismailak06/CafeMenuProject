using Entities.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations.Common
{
    public static class SoftDeleteConfiguration<TEntity> where TEntity : class, ISoftDelete
    {
        public static EntityTypeBuilder<TEntity> SetProperties(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(m => m.IsDeleted);

            builder.HasQueryFilter(m => !m.IsDeleted);

            return builder;
        }
    }
}
