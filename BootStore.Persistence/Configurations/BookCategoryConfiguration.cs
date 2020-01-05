using BookStore.Domain.Entities;
using BootStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootStore.Persistence.Configurations
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable(nameof(BookCategory));
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).IsRequired()
                .HasValueGenerator((p, t) => new GuidValueGenerator());
            builder.Property(category => category.BookId);
            builder.Property(category => category.CategoryId);
            builder.HasOne(category => category.Book).WithMany(category => category.BookCategories)
                .HasForeignKey(category => category.BookId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(category => category.Category).WithMany(category => category.BookCategories)
                .HasForeignKey(category => category.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
