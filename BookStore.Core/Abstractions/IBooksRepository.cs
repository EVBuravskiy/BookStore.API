using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories
{
    public interface IBooksRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid bookID);
        Task<Book> Get(Guid bookID);
        Task<List<Book>> GetAll();
        Task<Guid> Update(Guid bookID, string title, string description, decimal price);
    }
}