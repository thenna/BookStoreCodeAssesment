using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IBookAuthorRepository : IRepository<BookAuthor>
    {
        BookAuthor GetBookAuthor(string bookId);
    }
}
