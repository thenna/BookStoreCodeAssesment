using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author : EntityBase
    {
        public string AuthorName { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
