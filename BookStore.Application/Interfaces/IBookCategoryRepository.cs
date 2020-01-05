using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        BookCategory GetBookCategory(string bookId);
    }
}
