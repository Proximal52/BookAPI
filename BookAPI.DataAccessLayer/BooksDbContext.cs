using BookAPI.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataAccessLayer
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
        }
    }
}
