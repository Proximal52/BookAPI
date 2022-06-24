using BookAPI.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataAccessLayer
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookStorage;Trusted_Connection=True;");
        }
    }
}
