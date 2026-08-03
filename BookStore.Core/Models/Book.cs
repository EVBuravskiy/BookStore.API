namespace BookStore.Core.Models
{
    public class Book
    {
        public Guid BookID { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public const int MAX_TITLE_LENGTH = 250;
        
        private Book(Guid id, string title, string description, decimal price)
        {
            BookID = id;
            Title = title;
            Description = description;
            Price = price;
        }
        
        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "The title cannot be empty or longer than 250 characters";
            };
            Book newBook = new Book(id, title, description, price);

            return (newBook, error);
        }
    }
}
