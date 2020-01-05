namespace BookStore.Domain.Entities
{
    public class BookCategory : EntityBase
    {
        public string BookId { get; set; }
        public Book Book { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
