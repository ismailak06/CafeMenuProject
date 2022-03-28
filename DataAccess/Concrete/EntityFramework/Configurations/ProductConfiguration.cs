using DataAccess.Concrete.EntityFramework.Configurations.Common;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            AuditableEntityConfiguration<Product>.SetProperties(builder);
            SoftDeleteConfiguration<Product>.SetProperties(builder);

            builder.ToTable("Products");
            builder.Property(p => p.Name);
            builder.Property(p => p.CategoryId);
            builder.Property(p => p.Price);
            builder.Property(p => p.ImagePath);
            builder.Property(p => p.IsDeleted);
            builder.Property(p => p.CreationDate);
            builder.Property(p => p.CreatorUserId);
            builder.Property(p => p.DeletionDate);
            builder.Property(p => p.ModifiedDate);
            builder.Property(p => p.ModifiedUserId);
        }
    }
}
