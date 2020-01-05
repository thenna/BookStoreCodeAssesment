using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Category : EntityBase
    {
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
