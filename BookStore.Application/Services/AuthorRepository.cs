using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BootStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly DbContextOptionsBuilder<BookStoreContext> _optionsBuilder =
            new DbContextOptionsBuilder<BookStoreContext>();
        public AuthorRepository(DbContext context) : base(context) { }
        public BookStoreContext BookStoreContext => Context as BookStoreContext;
    }
}
