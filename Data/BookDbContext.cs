using Microsoft.EntityFrameworkCore;
using Lesson3_CNLTWeb.Models;

namespace Lesson3_CNLTWeb.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}