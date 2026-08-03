namespace BookStore.Core.Models
{
    public class Book
    {
        public Guid BookID { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
    }
}
