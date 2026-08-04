using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository bookRepository)
        {
            _booksRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.GetAll();
        }

        public async Task<Book> GetBook(Guid bookID)
        {
            return await _booksRepository.Get(bookID);
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid bookID, string title, string description, decimal price)
        {
            return await _booksRepository.Update(bookID, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid bookID)
        {
            return await _booksRepository.Delete(bookID);
        }
    }
}
