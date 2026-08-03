using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> GetAll()
        {
            List<BookEntity> bookEntities = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
            List<Book> books = bookEntities
                .Select(b => Book.Create(b.BookID, b.BookTitle, b.BookDescription, b.BookPrice).Book)
                .ToList();
            return books;
        }
        public async Task<Book> Get(Guid bookID)
        {
            BookEntity bookEntity = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookID == bookID);
            Book book = null;
            if (bookEntity != null)
            {
                book = Book.Create(bookEntity.BookID, bookEntity.BookTitle, bookEntity.BookDescription, bookEntity.BookPrice).Book;
            }
            return book;
        }
        public async Task<Guid> Create(Book book)
        {
            BookEntity bookEntity = new BookEntity()
            {
                BookID = book.BookID,
                BookTitle = book.Title,
                BookDescription = book.Description,
                BookPrice = book.Price,
            };
            await _dbContext.Books.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();
            return bookEntity.BookID;
        }
        public async Task<Guid> Update(Guid bookID, string title, string description, decimal price)
        {
            await _dbContext.Books
                .Where(b => b.BookID == bookID)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.BookTitle, b => title)
                .SetProperty(b => b.BookDescription, b => description)
                .SetProperty(b => b.BookPrice, b => price));
            return bookID;
        }
        public async Task<Guid> Delete(Guid bookID)
        {
            await _dbContext.Books
                .Where(b => b.BookID == bookID)
                .ExecuteDeleteAsync();
            return bookID;
        }
    }
}
