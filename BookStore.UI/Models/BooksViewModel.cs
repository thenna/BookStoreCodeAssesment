using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Models
{
    public class BooksViewModel : BooksPostViewModel
    {
        public string Id { get; set; }
    }

    public class BooksPostViewModel
    {
        [Required] public string Title { get; set; }
        [Required] public string Edition { get; set; }
        [Required] public Decimal Price { get; set; }
        [Required] public string Author { get; set; }
        [Required] public string Category { get; set; }
    }

    public class BookEditViewModel : BooksPostViewModel
    {
        [Required] public string Id { get; set; }
        [Required] public string AuthorId { get; set; }
        [Required] public string CategoryId { get; set; }
    }
}
