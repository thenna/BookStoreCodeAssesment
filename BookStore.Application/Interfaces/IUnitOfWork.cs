using System;

namespace BookStore.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IAuthorRepository AuthorRepository { get; set; }
        IBookCategoryRepository BookCategoryRepository { get; set; }
        IBookAuthorRepository BookAuthorRepository { get; set; }
        int SaveChanges();
    }
}
