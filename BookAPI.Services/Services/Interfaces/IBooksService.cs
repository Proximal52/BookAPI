using BookAPI.DataAccessLayer.Models;

namespace BookAPI.BusinessLogicLayer.Services.Interfaces
{
    public interface IBooksService
    {
        public Book GetBookById(int id);
        public List<Book> GetBooks();

        public void AddBook(Book book);
    }
}
