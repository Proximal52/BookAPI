using BookAPI.Common.Models;

namespace BookAPI.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// Repository for working with <see cref="Book"/> class
    /// </summary>
    public interface IBooksRepository
    {
        /// <summary>
        /// Get book from db by its id
        /// </summary>
        /// <param name="id">book's id in db</param>
        /// <returns>book object</returns>
        public Task<Book> GetBookByIdAsync(int id);

        /// <summary>
        /// Get all books from db
        /// </summary>
        /// <returns>all book obects</returns>
        public Task<List<Book>> GetAllBooksAsync();

        /// <summary>
        /// Add new book in db
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Added book with setted id and creation date</returns>
        public Task<Book> AddBookAsync(Book book);

        /// <summary>
        /// Update book in db
        /// </summary>
        /// <param name="book">New book state</param>
        public Task UpdateBookAsync(Book book);

        /// <summary>
        /// Delete book from db by id
        /// </summary>
        /// <param name="id">Id of book</param>
        public Task DeleteBookAsync(int id);
    }
}
