using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BootStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DbContextOptionsBuilder<BookStoreContext> _optionsBuilder =
            new DbContextOptionsBuilder<BookStoreContext>();
        public CategoryRepository(DbContext context) : base(context) { }
        public BookStoreContext BookStoreContext => Context as BookStoreContext;
    }
}
