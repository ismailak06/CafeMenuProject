using DataAccess.Concrete.EntityFramework.Configurations.Common;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            AuditableEntityConfiguration<Category>.SetProperties(builder);

            builder.ToTable("Categories");
            builder.Property(p => p.Name);
            builder.Property(p => p.ParentCategoryId);
            builder.Property(p => p.IsDeleted);
            builder.Property(p => p.CreationDate);
            builder.Property(p => p.CreatorUserId);
            builder.Property(p => p.ModifiedUserId);
            builder.Property(p => p.ModifiedDate);
            builder.Property(p => p.DeletionDate);
        }
    }
}
