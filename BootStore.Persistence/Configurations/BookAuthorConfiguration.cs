using BookStore.Domain.Entities;
using BootStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootStore.Persistence.Configurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable(nameof(BookAuthor));
            builder.HasKey(author => author.Id);
            builder.Property(author => author.Id).IsRequired()
                .HasValueGenerator((p, t) => new GuidValueGenerator());
            builder.Property(author => author.BookId);
            builder.Property(author => author.AuthorId);
            builder.HasOne(author => author.Book).WithMany(author => author.BookAuthors)
                .HasForeignKey(author => author.BookId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(author => author.Author).WithMany(author => author.BookAuthors)
                .HasForeignKey(author => author.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
