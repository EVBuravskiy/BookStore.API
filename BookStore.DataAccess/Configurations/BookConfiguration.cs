using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(book => book.BookID);
            builder.Property(book => book.BookTitle)
                .IsRequired()                           
                .HasMaxLength(Book.MAX_TITLE_LENGTH);   
            builder.Property(book => book.BookDescription)
                .IsRequired();                          
            builder.Property(book => book.BookPrice)
                .IsRequired();                          
        }
    }
}
