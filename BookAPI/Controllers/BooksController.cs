using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { new BookDto() });
        }

        [HttpGet("1")]
        public IActionResult Get(int id)
        {
            return Ok(new BookDto());
        }
    }
}
