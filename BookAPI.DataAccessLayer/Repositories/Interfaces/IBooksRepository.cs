using BookAPI.DataAccessLayer.Models;

namespace BookAPI.DataAccessLayer.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        public void AddBook(Book book);
    }
}
