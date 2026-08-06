using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is mandatory")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is mandatory")]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000.")]
        public decimal Price { get; set; }
    }
}
