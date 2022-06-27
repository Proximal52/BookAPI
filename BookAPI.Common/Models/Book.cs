using System.ComponentModel.DataAnnotations;

namespace BookAPI.Common.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAtUtc { get; private set; }

        public Book()
        {
            CreatedAtUtc = DateTime.UtcNow;
        }
    }
}
