using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public Decimal Price { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
