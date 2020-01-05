using BookStore.Domain.Entities;
using BootStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootStore.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).IsRequired().HasValueGenerator((p, t) => new GuidValueGenerator());
            builder.Property(category => category.CategoryName).IsRequired().HasMaxLength(300);
        }
    }
}
