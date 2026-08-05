using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class UpdateBookDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Range(1, 100000) ]
        public decimal Price { get; set; }
    }
}
