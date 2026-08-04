using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; } = null!;

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
