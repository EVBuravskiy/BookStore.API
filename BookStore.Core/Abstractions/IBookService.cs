using BookStore.Core.Models;

namespace BookStore.BL.Services
{
    public interface IBookService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid bookID);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(Guid bookID);
        Task<Guid> UpdateBook(Guid bookID, string title, string description, decimal price);
    }
}