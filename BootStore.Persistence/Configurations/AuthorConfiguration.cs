using BookStore.Domain.Entities;
using BootStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootStore.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));
            builder.HasKey(author => author.Id);
            builder.Property(author => author.Id).IsRequired().HasValueGenerator((p, t) => new GuidValueGenerator());
            builder.Property(author => author.AuthorName).IsRequired().HasMaxLength(300);
        }
    }
}
