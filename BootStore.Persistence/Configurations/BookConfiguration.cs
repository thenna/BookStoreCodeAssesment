using BookStore.Domain.Entities;
using BootStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootStore.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Id).IsRequired().HasValueGenerator((p, t) => new GuidValueGenerator());
            builder.Property(book => book.Title).IsRequired().HasMaxLength(500);
            builder.Property(book => book.Edition).IsRequired().HasMaxLength(100);
            builder.Property(book => book.Price).IsRequired();
        }
    }
}
