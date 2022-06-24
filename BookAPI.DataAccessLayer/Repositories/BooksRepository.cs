using BookAPI.DataAccessLayer.Models;
using BookAPI.DataAccessLayer.Repositories.Interfaces;

namespace BookAPI.DataAccessLayer.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public void AddBook(Book book)
        {
            using (BooksDbContext dbContext = new BooksDbContext())
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
        }
    }
}
