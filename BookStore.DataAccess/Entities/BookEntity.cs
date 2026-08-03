namespace BookStore.DataAccess.Entities
{
    public class BookEntity
    {
        public Guid BookID { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string BookDescription { get; set; } = string.Empty;
        public decimal BookPrice { get; set; }
    }
}
