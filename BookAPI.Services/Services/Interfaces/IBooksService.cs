using BookAPI.Common.Models;
using BookAPI.Common.Models.DTO;

namespace BookAPI.BusinessLogicLayer.Services.Interfaces
{
    /// <summary>
    /// Service for working with <see cref="Book"/> class
    /// </summary>
    public interface IBooksService
    {
        /// <summary>
        /// Get book by its id from db
        /// </summary>
        /// <param name="id">Book's id</param>
        /// <returns>Book object</returns>
        public Task<BookDto> GetBookByIdAsync(int id);

        /// <summary>
        /// Get all books from db
        /// </summary>
        /// <returns>All book obects</returns>
        public Task<List<BookDto>> GetAllBooksAsync();

        /// <summary>
        /// Add new book in db
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Added book with setted id and creation date</returns>
        public Task<BookDto> AddBookAsync(BookCreateDto book);

        /// <summary>
        /// Update book in db
        /// </summary>
        /// <param name="id">Id of book to update</param>
        /// <param name="book">Book to update</param>
        public Task UpdateBookAsync(int id, BookUpdateDto book);

        /// <summary>
        /// Delete book from db by its id
        /// </summary>
        /// <param name="id">Id of book to delete</param>
        public Task DeleteBookAsync(int id);
    }
}
