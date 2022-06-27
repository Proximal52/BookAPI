using BookAPI.BusinessLogicLayer.Services.Interfaces;
using BookAPI.Common.Exceptions;
using BookAPI.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _booksService.GetAllBooksAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _booksService.GetBookByIdAsync(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookCreateDto bookCreateDto)
        {
            var newBook = await _booksService.AddBookAsync(bookCreateDto);
            return Created($"Books/{newBook.Id}", newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BookUpdateDto bookUpdateDto)
        {
            try
            {
                await _booksService.UpdateBookAsync(id, bookUpdateDto);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
                
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _booksService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
