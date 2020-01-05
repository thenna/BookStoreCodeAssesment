using System.Linq;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BootStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        private readonly DbContextOptionsBuilder<BookStoreContext> _optionsBuilder =
            new DbContextOptionsBuilder<BookStoreContext>();
        public BookCategoryRepository(DbContext context) : base(context) { }
        public BookStoreContext BookStoreContext => Context as BookStoreContext;

        public BookCategory GetBookCategory(string bookId)
        {
            var data = BookStoreContext.BookCategories.Where(author => author.BookId == bookId)
                .Include(author => author.Category).FirstOrDefault();
            return data;
        }
    }
}
