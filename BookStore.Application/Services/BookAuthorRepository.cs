using System.Linq;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BootStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class BookAuthorRepository : Repository<BookAuthor>, IBookAuthorRepository
    {
        private readonly DbContextOptionsBuilder<BookStoreContext> _optionsBuilder =
            new DbContextOptionsBuilder<BookStoreContext>();
        public BookAuthorRepository(DbContext context) : base(context) { }
        public BookStoreContext BookStoreContext => Context as BookStoreContext;

        public BookAuthor GetBookAuthor(string bookId)
        {
            var data = BookStoreContext.BookAuthors.Where(author => author.BookId == bookId)
                .Include(author => author.Author).FirstOrDefault();
            return data;
        }
    }
}
