using BookAPI.Common.Exceptions;
using BookAPI.Common.Models;
using BookAPI.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataAccessLayer.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksDbContext _context;

        public BooksRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var result = _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteBookAsync(int id)
        {
            var deletedBook = await _context.Books.FindAsync(id);

            if (deletedBook is null)
            {
                throw new NotFoundException();
            }

            _context.Books.Remove(deletedBook);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}