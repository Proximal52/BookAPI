using BookAPI.BusinessLogicLayer.Services.Interfaces;
using BookAPI.DataAccessLayer.Models;
using BookAPI.DataAccessLayer.Repositories.Interfaces;

namespace BookAPI.BusinessLogicLayer.Services
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public void AddBook(Book book)
        {
            _booksRepository.AddBook(book);
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
