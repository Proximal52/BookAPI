using AutoMapper;
using BookAPI.BusinessLogicLayer.Services.Interfaces;
using BookAPI.Common.Exceptions;
using BookAPI.Common.Models;
using BookAPI.Common.Models.DTO;
using BookAPI.DataAccessLayer.Repositories.Interfaces;

namespace BookAPI.BusinessLogicLayer.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> AddBookAsync(BookCreateDto book)
        {
            var result = await _booksRepository.AddBookAsync(_mapper.Map<Book>(book));

            return _mapper.Map<BookDto>(result);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var addedBook = await _booksRepository.GetBookByIdAsync(id);

            if (addedBook == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<BookDto>(addedBook);
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var resultList = await _booksRepository.GetAllBooksAsync();
            return resultList.Select(x => _mapper.Map<BookDto>(x)).ToList();
        }

        public async Task UpdateBookAsync(int id, BookUpdateDto bookDto)
        {
            var bookFromDb = await _booksRepository.GetBookByIdAsync(id);

            if (bookFromDb is null)
            {
                throw new NotFoundException();
            }

            var book = _mapper.Map(bookDto, bookFromDb);

            await _booksRepository.UpdateBookAsync(_mapper.Map<Book>(book));
        }

        public async Task DeleteBookAsync(int id)
        {
            await _booksRepository.DeleteBookAsync(id);
        }
    }
}
