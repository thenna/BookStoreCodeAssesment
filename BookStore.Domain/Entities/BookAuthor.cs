using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BookAuthor : EntityBase
    {
        public string BookId { get; set; }
        public Book Book { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
