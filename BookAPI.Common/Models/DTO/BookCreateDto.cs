using System.ComponentModel.DataAnnotations;

namespace BookAPI.Common.Models.DTO
{
    public class BookCreateDto
    {
        public string Author { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
