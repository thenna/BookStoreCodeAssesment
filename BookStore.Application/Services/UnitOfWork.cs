using BookStore.Application.Interfaces;
using BootStore.Persistence;

namespace BookStore.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _context;

        public UnitOfWork(BookStoreContext context)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            AuthorRepository = new AuthorRepository(_context);
            BookCategoryRepository = new BookCategoryRepository(_context);
            BookAuthorRepository = new BookAuthorRepository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public IBookRepository BookRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        public IBookCategoryRepository BookCategoryRepository { get; set; }
        public IBookAuthorRepository BookAuthorRepository { get; set; }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                //TODO : Log the exception to somewhere
                return 0;
            }
        }
    }
}